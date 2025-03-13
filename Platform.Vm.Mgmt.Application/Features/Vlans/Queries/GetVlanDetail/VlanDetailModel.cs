using Platform.Vm.Mgmt.Application.Features.Environments.Queries.GetEnvironmentsList;

namespace Platform.Vm.Mgmt.Application.Features.Vlans.Queries.GetVlanDetail
{
    public class VlanDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public Guid EnvironmentId { get; set; }
        public EnvironmentListModel EnvironmentListModel { get; set; } = default!;
    }
}