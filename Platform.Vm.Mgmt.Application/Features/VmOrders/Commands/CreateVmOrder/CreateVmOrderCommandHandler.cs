using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder
{
    public class CreateVmOrderCommandHandler
        : IRequestHandler<CreateVmOrderCommand, CreateVmOrderCommandResponse>
    {
        private readonly ILogger<CreateVmOrderCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IVmOrderRepository _vmOrderRepository;

        private readonly IEmailService _emailService;
        private readonly ISlackNotificationService _slackNotificationService;

        public CreateVmOrderCommandHandler(
            ILogger<CreateVmOrderCommandHandler> logger,
            IMapper mapper,
            IVmOrderRepository vmOrderRepository,
            IEmailService emailService,
            ISlackNotificationService slackNotificationService)
        {
            _logger = logger;
            _mapper = mapper;
            _vmOrderRepository = vmOrderRepository;
            _emailService = emailService;
            _slackNotificationService = slackNotificationService;
        }
        public async Task<CreateVmOrderCommandResponse>
            Handle(CreateVmOrderCommand request, CancellationToken cancellationToken)
        {
            var createVmOrderCommandResponse = new CreateVmOrderCommandResponse();

            var validator = new CreateVmOrderCommandValidator(_vmOrderRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                _logger.LogWarning($"*** CreateVmOrderCommandHandler - VmOrder Validation Failed: {createVmOrderCommandResponse.ValidationErrors}");

                throw new ValidationException(validationResult);
            }

            if(createVmOrderCommandResponse.Success)
            {
                var vmOrder = new Domain.Entities.VmOrder()
                {
                    Name = request.Name,
                    Description = request.Description,

                    EnvironmentId = request.EnvironmentId,

                    TimeZoneId = request.TimeZoneId,

                    PrimaryContactName = request.PrimaryContactName,
                    PrimaryContactEmail = request.PrimaryContactEmail,
                    TeamName = request.TeamName,

                    VmOrderPlaced = DateTime.Now
                };

                if(request.VmOrderDetails is not null)
                {
                    var vmOrderDetails = new List<Domain.Entities.VmOrderDetail>();

                    foreach(var vmOrderDetailLine in request.VmOrderDetails)
                    {
                        var vmOrderDetail = new Domain.Entities.VmOrderDetail()
                        {
                            VmTypeId = vmOrderDetailLine.VmTypeId,
                            VmSizeId = vmOrderDetailLine.VmSizeId
                        };

                        vmOrderDetails.Add(vmOrderDetail);
                    }

                    vmOrder.VmOrderDetails = vmOrderDetails;
                }

                vmOrder = await _vmOrderRepository.AddAsync(vmOrder);

                createVmOrderCommandResponse.VmOrderId = vmOrder.Id;

                var createVmOrderModel = _mapper.Map<CreateVmOrderModel>(vmOrder);

                createVmOrderCommandResponse.CreateVmOrderModel = createVmOrderModel;

                _logger.LogInformation($"*** CreateVmOrderCommandHandler - VmOrder {vmOrder.Name} was created.");

                await SendCreationSuccessEmail(createVmOrderCommandResponse);
            }

            return createVmOrderCommandResponse;
        }

        private async Task<bool> SendCreationSuccessEmail(CreateVmOrderCommandResponse response)
        {
            var success = false;

            try
            {
                var email = new Models.Email.Email()
                {
                    To = "noreply@myemail.com",
                    Body = $"A new VM Order was created: {response.CreateVmOrderModel}",
                    Subject = "A new VM Order was created"
                };

                success = await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"*** CreateVmOrderCommandHandler : SendCreationSuccessEmail ({response.CreateVmOrderModel.Name}) - Error sending email: {ex.Message}");
            }

            return success;
        }
    }
}