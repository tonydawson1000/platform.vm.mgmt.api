using Platform.Vm.Mgmt.Application.Responses;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder
{
    public class CreateVmOrderCommandResponse : BaseResponse
    {
        public CreateVmOrderCommandResponse() : base() { }

        public Guid VmOrderId { get; set; }

        public CreateVmOrderModel CreateVmOrderModel { get; set; } = default!;
    }
}