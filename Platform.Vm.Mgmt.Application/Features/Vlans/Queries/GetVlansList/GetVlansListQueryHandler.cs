using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlansList
{
    public class GetVlansListQueryHandler
        : IRequestHandler<GetVlansListQuery, GetVlansListQueryResponse>
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

        public async Task<GetVlansListQueryResponse>
            Handle(GetVlansListQuery request, CancellationToken cancellationToken)
        {
            var getVlansListQueryResponse = new GetVlansListQueryResponse();

            var allVlans = (await _vlanRepository.ListAllAsync()).OrderBy(x => x.Name);

            var vlanListModels = _mapper.Map<List<VlanListModel>>(allVlans);

            getVlansListQueryResponse.VlanListModels = vlanListModels;

            return getVlansListQueryResponse;
        }
    }
}