using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class Environment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsEnabled { get; set; } = true;
        public int? Sequence { get; set; }

        public int? Tier { get; set; }

        public Guid DataCentreId { get; set; }
        public DataCentre DataCentre { get; set; } = default!;

        public ICollection<Vlan>? Vlans { get; set; }
    }
}