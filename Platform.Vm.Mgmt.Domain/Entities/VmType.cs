using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class VmType : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }
    }
}