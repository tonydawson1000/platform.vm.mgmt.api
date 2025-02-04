using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class VmOrder : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public Guid UserId { get; set; }
        public DateTime VmOrderPlaced { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDescription { get; set; }

        public Guid EnvironmentId { get; set; }
        public Environment Environment { get; set; } = default!;

        public Guid TimeZoneId {  get; set; }
        public TimeZone TimeZone { get; set; } = default!;

        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? TeamName { get; set; }

        public string? ServiceAccountName { get; set; }

        public string? AdminAdGroupName { get; set; }
        public string? UserAdGroupName { get; set; }

        //TODO : TD Split into 'Order Lines' if multiples required (YAGNI ?)
        public Guid VmTypeId { get; set; }
        public VmType VmType { get; set; } = default!;

        public Guid VmSizeId { get; set; }
        public VmSize VmSize { get; set; } = default!;

        public int? VmCount { get; set; }
    }
}