using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Platform.Vm.Mgmt.Persistence.EfCore.Configurations
{
    public class DataCentreConfiguration : IEntityTypeConfiguration<Domain.Entities.DataCentre>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.DataCentre> builder)
        {
            builder.Property(dc => dc.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(dc => dc.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(dc => dc.Location)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}