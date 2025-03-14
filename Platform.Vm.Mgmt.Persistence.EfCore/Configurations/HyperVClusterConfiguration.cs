using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class HyperVClusterConfiguration : IEntityTypeConfiguration<Domain.Entities.HyperVCluster>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.HyperVCluster> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}