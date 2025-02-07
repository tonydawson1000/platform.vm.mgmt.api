using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Environments.Commands.CreateEnvironment
{
    public class CreateEnvironmentCommandHandler
        : IRequestHandler<CreateEnvironmentCommand, CreateEnvironmentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEnvironmentRepository _environmentRepository;

        public CreateEnvironmentCommandHandler(
            IMapper mapper,
            IEnvironmentRepository environmentRepository)
        {
            _mapper = mapper;
            _environmentRepository = environmentRepository;
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
            }

            if (createEnvironmentCommandResponse.Success)
            {
                var environment = new Domain.Entities.Environment()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsEnabled = request.IsEnabled,
                    
                    Sequence = request.Sequence,

                    DataCentreId = request.DataCentreId
                };

                environment = await _environmentRepository.AddAsync(environment);
                
                var createEnvironmentModel = _mapper.Map<CreateEnvironmentModel>(environment);

                createEnvironmentCommandResponse.CreateEnvironmentModel = createEnvironmentModel;
            }

            return createEnvironmentCommandResponse;
        }
    }
}