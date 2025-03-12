namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList
{
    public class VmOrderListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public Guid EnvironmentId { get; set; }

        public DateTime VmOrderPlaced { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public ICollection<VmOrderDetailListModel>? VmOrderDetailListModels { get; set; }
    }
}