using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class VmSizeConfiguration : IEntityTypeConfiguration<Domain.Entities.VmSize>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.VmSize> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.CpuCount)
                .IsRequired();

            builder.Property(e => e.RamGb)
                .IsRequired();

            builder.Property(e => e.HddGb)
                .IsRequired();
        }
    }
}