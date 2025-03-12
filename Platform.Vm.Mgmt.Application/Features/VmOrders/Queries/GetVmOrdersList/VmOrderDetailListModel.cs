namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList
{
    public class VmOrderDetailListModel
    {
        public Guid Id { get; set; }

        public Guid VmTypeId { get; set; }

        public Guid VmSizeId { get; set; }
    }
}