using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Notification;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.DataCentres.Commands.CreateDataCentre
{
    public class CreateDataCentreCommandHandler
        : IRequestHandler<CreateDataCentreCommand, CreateDataCentreCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDataCentreRepository _dataCentreRepository;

        private readonly IEmailService _emailService;
        private readonly ISlackNotificationService _slackNotificationService;

        public CreateDataCentreCommandHandler(
            IMapper mapper,
            IDataCentreRepository dataCentreRepository,
            IEmailService emailService,
            ISlackNotificationService slackNotificationService)
        {
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
                createDataCentreCommandResponse.Success = false;
                createDataCentreCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDataCentreCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                //TODO : TD - Plug in 'Validation Failure on Creation' Email/Notification here ...
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

                var createDataCentreModel = _mapper.Map<CreateDataCentreModel>(dataCentre);

                createDataCentreCommandResponse.CreateDataCentreModel = createDataCentreModel;

                //TODO : TD - Plug in 'Creation Success' Email/Notification here ...

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
                var str = ex.Message;

                //Fire and Forget ...
                //TODO : TD - Log it
            }

            return success;
        }
    }
}