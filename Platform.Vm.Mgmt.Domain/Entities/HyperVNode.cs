using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class HyperVNode : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public string HostName { get; set; } = string.Empty;

        public Guid HyperVClusterId { get; set; }
        public HyperVCluster HyperVCluster { get; set; } = default!;

        public Guid DataCentreId { get; set; }
        public DataCentre DataCentre { get; set; } = default!;
    }
}