using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan
{
    public class CreateVlanCommandHandler
        : IRequestHandler<CreateVlanCommand, CreateVlanCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVlanRepository _vlanRepository;

        public CreateVlanCommandHandler(
            IMapper mapper,
            IVlanRepository vlanRepository)
        {
            _mapper = mapper;
            _vlanRepository = vlanRepository;
        }

        public async Task<CreateVlanCommandResponse>
            Handle(CreateVlanCommand request, CancellationToken cancellationToken)
        {
            var createVlanCommandResponse = new CreateVlanCommandResponse();

            var validator = new CreateVlanCommandValidator(_vlanRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                createVlanCommandResponse.Success = false;
                createVlanCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createVlanCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createVlanCommandResponse.Success)
            {
                var vlan = new Domain.Entities.Vlan()
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsEnabled = request.IsEnabled,

                    EnvironmentId = request.EnvironmentId
                };

                vlan = await _vlanRepository.AddAsync(vlan);

                var createVlanModel = _mapper.Map<CreateVlanModel>(vlan);

                createVlanCommandResponse.CreateVlanModel = createVlanModel;
            }

            return createVlanCommandResponse;
        }
    }
}