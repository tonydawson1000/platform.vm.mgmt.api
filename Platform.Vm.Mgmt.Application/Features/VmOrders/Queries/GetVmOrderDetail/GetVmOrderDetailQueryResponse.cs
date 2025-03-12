using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail
{
    public class GetVmOrderDetailQueryResponse : BaseResponse
    {
        public GetVmOrderDetailQueryResponse() : base() { }

        public VmOrderDetailModel? VmOrderDetailModel { get; set; }
    }
}