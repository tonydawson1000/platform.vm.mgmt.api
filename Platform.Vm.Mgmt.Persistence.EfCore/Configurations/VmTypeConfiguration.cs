using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class VmTypeConfiguration : IEntityTypeConfiguration<Domain.Entities.VmType>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.VmType> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.OsType)
                .IsRequired();

            builder.Property(e => e.OsVersion)
                .IsRequired();
        }
    }
}