namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Commands.CreateVmOrder
{
    public class CreateVmOrderDetailModel
    {
        public Guid VmTypeId { get; set; }

        public Guid VmSizeId { get; set; }
    }
}