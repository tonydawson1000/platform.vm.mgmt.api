using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList
{
    public class GetVmOrdersListQueryResponse: BaseResponse
    {
        public GetVmOrdersListQueryResponse() : base() { }

        public List<VmOrderListModel>? VmOrderListModels { get; set; }
    }
}