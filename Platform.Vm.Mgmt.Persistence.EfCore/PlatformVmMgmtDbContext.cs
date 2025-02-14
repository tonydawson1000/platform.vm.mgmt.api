using Microsoft.EntityFrameworkCore;
using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Persistence.EfCore
{
    public class PlatformVmMgmtDbContext : DbContext
    {
        public PlatformVmMgmtDbContext(DbContextOptions<PlatformVmMgmtDbContext> options)
            : base(options) { }

        public DbSet<Domain.Entities.DataCentre> DataCentres { get; set; }
        public DbSet<Domain.Entities.Environment> Environments { get; set; }
        public DbSet<Domain.Entities.Vlan> Vlans { get; set; }

        private Guid DcShGuid = Guid.Parse("{D18519B3-4B35-4D5A-8720-2593881615E5}");
        private Guid DcPgGuid = Guid.Parse("{D28519B3-4B35-4D5A-8720-2593881615E5}");
        private Guid DcMa4Guid = Guid.Parse("{D38519B3-4B35-4D5A-8720-2593881615E5}");

        private Guid EnvDevGuid = Guid.Parse("{E1B64577-1C93-4D83-A160-D0C100B75C0C}");
        private Guid EnvOatGuid = Guid.Parse("{E2B64577-1C93-4D83-A160-D0C100B75C0C}");
        private Guid EnvUatGuid = Guid.Parse("{E3B64577-1C93-4D83-A160-D0C100B75C0C}");
        private Guid EnvProdGuid = Guid.Parse("{E4B64577-1C93-4D83-A160-D0C100B75C0C}");

        private Guid Vlan113Guid = Guid.Parse("{113D0837-E1E4-4078-8DA3-9F62A4C33C58}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformVmMgmtDbContext).Assembly);

            //Seed DC's
            SeedDataCentres(modelBuilder);

            //Seed Env's
            SeedEnvironments(modelBuilder);

            //Seed VLAN's
            SeedVlans(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private void SeedVlans(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Vlan>().HasData(new Domain.Entities.Vlan
            {
                Id = Vlan113Guid,
                Name = "ML-DEV-PG",
                Description = "NEW VLAN in ML for DEV Deployments of VMs ...",
                IsEnabled = true,

                EnvironmentId = EnvDevGuid
            });
        }

        private void SeedEnvironments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvDevGuid,
                Name = "Development",
                Description = "Houses resources required for development purposes, including (but not limited to) day-to-day development, automated integration (INT) testing, systems integration testing (SIT), internal demos.",
                IsEnabled = true,

                Tier = 4,
                Sequence = 1,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvOatGuid,
                Name = "Operational Acceptance Testing",
                Description = "Provides the environment for operational acceptance testing, including failover and performance testing.",
                IsEnabled = true,

                Tier = 3,
                Sequence = 2,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvUatGuid,
                Name = "User Acceptance Testing",
                Description = "Final verification testing for software changes from customer end-users.",
                IsEnabled = true,

                Tier = 2,
                Sequence = 3,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvProdGuid,
                Name = "Production Systems",
                Description = "Live operational environment at the very highest level of isolation. This houses the services that customers pay to use at a 99.9% availability SLA.",
                IsEnabled = true,

                Tier = 1,
                Sequence = 4,

                DataCentreId = DcShGuid
            });
        }

        private void SeedDataCentres(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.DataCentre>().HasData(new Domain.Entities.DataCentre
            {
                Id = DcShGuid,
                Name = "Sov House",
                Description = "Primary DC",
                IsEnabled = true,
                Location = "London, UK"
            });

            modelBuilder.Entity<Domain.Entities.DataCentre>().HasData(new Domain.Entities.DataCentre
            {
                Id = DcPgGuid,
                Name = "Power Gate",
                Description = "Secondary DC",
                IsEnabled = true,
                Location = "London, UK"
            });

            modelBuilder.Entity<Domain.Entities.DataCentre>().HasData(new Domain.Entities.DataCentre
            {
                Id = DcMa4Guid,
                Name = "MA-4",
                Description = "DC in the North",
                IsEnabled = true,
                Location = "Manchester, UK"
            });
        }

    }
}