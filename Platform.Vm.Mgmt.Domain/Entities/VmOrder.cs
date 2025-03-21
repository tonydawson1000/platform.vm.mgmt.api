﻿using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class VmOrder : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public DateTime VmOrderPlaced { get; set; }

        public Guid EnvironmentId { get; set; }
        public Environment Environment { get; set; } = default!;

        public Guid TimeZoneId {  get; set; }
        public TimeZone TimeZone { get; set; } = default!;

        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? TeamName { get; set; }

        public ICollection<VmOrderDetail>? VmOrderDetails { get; set; }
    }
}