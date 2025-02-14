using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class VlanConfiguration : IEntityTypeConfiguration<Domain.Entities.Vlan>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Vlan> builder)
        {
            builder.Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Description)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}