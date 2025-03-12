using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class VmOrderConfiguration : IEntityTypeConfiguration<Domain.Entities.VmOrder>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.VmOrder> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.PrimaryContactName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.PrimaryContactEmail)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.TeamName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}