using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class EnvironmentConfiguration : IEntityTypeConfiguration<Domain.Entities.Environment>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Environment> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Tier)
                .IsRequired();

            builder.Property(e => e.Sequence)
                .IsRequired();
        }
    }
}