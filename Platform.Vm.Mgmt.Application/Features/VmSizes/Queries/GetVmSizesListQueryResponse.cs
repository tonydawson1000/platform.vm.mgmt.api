using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.VmSizes.Queries
{
    public class GetVmSizesListQueryResponse : BaseResponse
    {
        public GetVmSizesListQueryResponse() : base() { }

        public List<VmSizeListModel>? VmSizeListModels { get; set; }
    }
}