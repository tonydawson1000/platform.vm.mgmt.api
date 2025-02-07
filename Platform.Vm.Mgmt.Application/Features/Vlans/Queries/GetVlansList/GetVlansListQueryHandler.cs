using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList
{
    public class GetVlansListQueryHandler
        : IRequestHandler<GetVlansListQuery, List<VlanListModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Domain.Entities.Vlan> _vlanRepository;

        public GetVlansListQueryHandler(
            IMapper mapper,
            IAsyncRepository<Domain.Entities.Vlan> vlanRepository)
        {
            _mapper = mapper;
            _vlanRepository = vlanRepository;
        }

        public async Task<List<VlanListModel>>
            Handle(GetVlansListQuery request, CancellationToken cancellationToken)
        {
            var allVlans = (await _vlanRepository.ListAllAsync()).OrderBy(x => x.Environment.Name);

            var vlanListModels = _mapper.Map<List<VlanListModel>>(allVlans);
           
            return vlanListModels;
        }
    }
}