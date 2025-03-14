using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClustersList
{
    public class GetHyperVClustersListQueryResponse : BaseResponse
    {
        public GetHyperVClustersListQueryResponse() : base() { }

        public List<HyperVClusterListModel>? HyperVClusterListModels { get; set; }
    }
}