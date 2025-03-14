using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.HyperVClusters.Queries.GetHyperVClusterDetail
{
    public class GetHyperVClusterDetailQueryResponse : BaseResponse
    {
        public GetHyperVClusterDetailQueryResponse() : base() { }

        public HyperVClusterDetailModel? HyperVClusterDetailModel { get; set; }
    }
}