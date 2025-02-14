using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure;
using Platform.Vm.Mgmt.Application.Contracts.Infrastructure.Email;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Commands.CreateVlan
{
    public class CreateVlanCommandHandler
        : IRequestHandler<CreateVlanCommand, CreateVlanCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVlanRepository _vlanRepository;

        private readonly IEmailService _emailService;
        private readonly INotificationService _notificationService;

        public CreateVlanCommandHandler(
            IMapper mapper,
            IVlanRepository vlanRepository,
            IEmailService emailService,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _vlanRepository = vlanRepository;
            _emailService = emailService;
            _notificationService = notificationService;
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

                //TODO : TD - Plug in 'Validation Failure on Creation' Email/Notification here ...
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

                //TODO : TD - Plug in 'Creation Success' Email/Notification here ...
            }

            return createVlanCommandResponse;
        }
    }
}