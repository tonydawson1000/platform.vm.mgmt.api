using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Exceptions;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre
{
    public class CreateDataCentreCommandHandler
        : IRequestHandler<CreateDataCentreCommand, CreateDataCentreCommandResponse>
    {
        private readonly ILogger<CreateDataCentreCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IDataCentreRepository _dataCentreRepository;

        private readonly IEmailService _emailService;
        private readonly ISlackNotificationService _slackNotificationService;

        public CreateDataCentreCommandHandler(
            ILogger<CreateDataCentreCommandHandler> logger,
            IMapper mapper,
            IDataCentreRepository dataCentreRepository,
            IEmailService emailService,
            ISlackNotificationService slackNotificationService)
        {
            _logger = logger;
            _mapper = mapper;
            _dataCentreRepository = dataCentreRepository;
            _emailService = emailService;
            _slackNotificationService = slackNotificationService;
        }

        public async Task<CreateDataCentreCommandResponse>
            Handle(CreateDataCentreCommand request, CancellationToken cancellationToken)
        {
            var createDataCentreCommandResponse = new CreateDataCentreCommandResponse();

            var validator = new CreateDataCentreCommandValidator(_dataCentreRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {

                _logger.LogWarning($"*** CreateDataCentreCommandHandler - DataCentre Validation Failed: {createDataCentreCommandResponse.ValidationErrors}");

                throw new ValidationException(validationResult);
            }

            if (createDataCentreCommandResponse.Success)
            {
                var dataCentre = new Domain.Entities.DataCentre()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsEnabled = request.IsEnabled,

                    Location = request.Location
                };

                dataCentre = await _dataCentreRepository.AddAsync(dataCentre);

                createDataCentreCommandResponse.DataCentreId = dataCentre.Id;

                var createDataCentreModel = _mapper.Map<CreateDataCentreModel>(dataCentre);

                createDataCentreCommandResponse.CreateDataCentreModel = createDataCentreModel;

                _logger.LogInformation($"*** CreateDataCentreCommandHandler - DataCentre {dataCentre.Name} was created.");

                await SendCreationSuccessEmail(createDataCentreCommandResponse);
            }

            return createDataCentreCommandResponse;
        }

        private async Task<bool> SendCreationSuccessEmail(CreateDataCentreCommandResponse response)
        {
            var success = false;

            try
            {
                var email = new Models.Email.Email()
                {
                    To = "noreply@myemail.com",
                    Body = $"A new DataCentre was created: {response.CreateDataCentreModel}",
                    Subject = "A new DataCentre was created"
                };

                success = await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"*** CreateDataCentreCommandHandler : SendCreationSuccessEmail ({response.CreateDataCentreModel.Name}) - Error sending email: {ex.Message}");
            }

            return success;
        }
    }
}