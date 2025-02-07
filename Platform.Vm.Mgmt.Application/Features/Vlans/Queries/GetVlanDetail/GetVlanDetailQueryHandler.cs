using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;
using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail
{
    public class GetVlanDetailQueryHandler
        : IRequestHandler<GetVlanDetailQuery, VlanDetailModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Vlan> _vlanRepository;
        private readonly IAsyncRepository<Domain.Entities.Environment> _environmentRepository;

        public GetVlanDetailQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Vlan> vlanRepository,
            IAsyncRepository<Domain.Entities.Environment> environmentRepository)
        {
            _mapper = mapper;
            _vlanRepository = vlanRepository;
            _environmentRepository = environmentRepository;
        }

        public async Task<VlanDetailModel>
            Handle(GetVlanDetailQuery request, CancellationToken cancellationToken)
        {
            var vlan = await _vlanRepository.GetByIdAsync(request.Id);
            var vlanDetailModel = _mapper.Map<VlanDetailModel>(vlan);

            var environment = await _environmentRepository.GetByIdAsync(vlan.EnvironmentId);
            var environmentListModel = _mapper.Map<EnvironmentListModel>(environment);

            vlanDetailModel.EnvironmentListModel = environmentListModel;

            return vlanDetailModel;
        }
    }
}