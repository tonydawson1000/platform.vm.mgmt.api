using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class Vlan : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }

        public Guid EnvironmentId { get; set; }
        public Environment Environment { get; set; } = default!;
    }
}