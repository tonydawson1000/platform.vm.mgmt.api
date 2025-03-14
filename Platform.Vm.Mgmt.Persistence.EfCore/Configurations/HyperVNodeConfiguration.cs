using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class HyperVNodeConfiguration : IEntityTypeConfiguration<Domain.Entities.HyperVNode>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.HyperVNode> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.HostName)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}