using MediatR;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail
{
    public class GetVmOrderDetailQuery : IRequest<GetVmOrderDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }
}