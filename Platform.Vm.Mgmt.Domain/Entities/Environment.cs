using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class Environment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }

        public int? Sequence { get; set; }

        public Guid DataCentreId { get; set; }
        public DataCentre DataCentre { get; set; } = default!;

        public ICollection<Vlan>? Vlans { get; set; }
    }
}