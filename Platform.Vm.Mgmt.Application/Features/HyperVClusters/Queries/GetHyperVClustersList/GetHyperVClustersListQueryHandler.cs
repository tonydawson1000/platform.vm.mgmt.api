using AutoMapper;
using MediatR;
using Platform.Vm.Mgmt.Application.Contracts.Persistence;

namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClustersList
{
    public class GetHyperVClustersListQueryHandler
        : IRequestHandler<GetHyperVClustersListQuery, GetHyperVClustersListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IHyperVClusterRepository _hyperVClusterRepository;

        public GetHyperVClustersListQueryHandler(
            IMapper mapper,
            IHyperVClusterRepository hyperVClusterRepository)
        {
            _mapper = mapper;
            _hyperVClusterRepository = hyperVClusterRepository;
        }

        public async Task<GetHyperVClustersListQueryResponse>
            Handle(GetHyperVClustersListQuery request, CancellationToken cancellationToken)
        {
            var getHyperVClustersListQueryResponse = new GetHyperVClustersListQueryResponse();

            var allHyperVClusters = await _hyperVClusterRepository.GetHyperVClustersAsync(true);

            var hyperVClustersListModels = _mapper.Map<List<HyperVClusterListModel>>(allHyperVClusters);

            getHyperVClustersListQueryResponse.HyperVClusterListModels = hyperVClustersListModels;

            return getHyperVClustersListQueryResponse;
        }
    }
}