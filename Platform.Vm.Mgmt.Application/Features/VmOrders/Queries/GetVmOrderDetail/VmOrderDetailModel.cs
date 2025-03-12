using Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrdersList;

namespace Platform.Vm.Mgmt.Application.Features.VmOrders.Queries.GetVmOrderDetail
{
    public class VmOrderDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime VmOrderPlaced { get; set; }

        public Guid EnvironmentId { get; set; }

        public Guid TimeZoneId { get; set; }

        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? TeamName { get; set; }

        public ICollection<VmOrderDetailListModel>? VmOrderDetailListModels { get; set; }
    }
}