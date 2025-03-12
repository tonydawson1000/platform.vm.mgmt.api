using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class VmOrderDetailConfiguration : IEntityTypeConfiguration<Domain.Entities.VmOrderDetail>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.VmOrderDetail> builder)
        {
            builder.Property(e => e.VmOrderId)
                .IsRequired();

            builder.Property(e => e.VmTypeId)
                .IsRequired();

            builder.Property(e => e.VmSizeId)
                .IsRequired();
        }
    }
}