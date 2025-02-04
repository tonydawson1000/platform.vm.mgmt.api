using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class TimeZone : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; }
    }
}