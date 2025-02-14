using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment
{
    public class CreateEnvironmentCommandHandler
        : IRequestHandler<CreateEnvironmentCommand, CreateEnvironmentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEnvironmentRepository _environmentRepository;

        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;

        public CreateEnvironmentCommandHandler(
            IMapper mapper,
            IEnvironmentRepository environmentRepository,
            IEmailService emailService,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _environmentRepository = environmentRepository;
            _emailService = emailService;
            _notificationService = notificationService;
        }

        public async Task<CreateEnvironmentCommandResponse>
            Handle(CreateEnvironmentCommand request, CancellationToken cancellationToken)
        {
            var createEnvironmentCommandResponse = new CreateEnvironmentCommandResponse();

            var validator = new CreateEnvironmentCommandValidator(_environmentRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                createEnvironmentCommandResponse.Success = false;
                createEnvironmentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createEnvironmentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }

                //TODO : TD - Plug in 'Validation Failure on Creation' Email/Notification here ...
            }

            if (createEnvironmentCommandResponse.Success)
            {
                var environment = new Domain.Entities.Environment()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsEnabled = request.IsEnabled,
                    
                    Tier = request.Tier,

                    Sequence = request.Sequence,

                    DataCentreId = request.DataCentreId
                };

                environment = await _environmentRepository.AddAsync(environment);
                
                var createEnvironmentModel = _mapper.Map<CreateEnvironmentModel>(environment);

                createEnvironmentCommandResponse.CreateEnvironmentModel = createEnvironmentModel;

                //TODO : TD - Plug in 'Creation Success' Email/Notification here ...
            }

            return createEnvironmentCommandResponse;
        }
    }
}