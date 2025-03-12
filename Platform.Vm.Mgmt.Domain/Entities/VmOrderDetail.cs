using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Domain.Entities
{
    public class VmOrderDetail : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid VmOrderId { get; set; }
        public VmOrder VmOrder { get; set; } = default!;

        public Guid VmTypeId { get; set; }
        public VmType VmType { get; set; } = default!;

        public Guid VmSizeId { get; set; }
        public VmSize VmSize { get; set; } = default!;
    }
}