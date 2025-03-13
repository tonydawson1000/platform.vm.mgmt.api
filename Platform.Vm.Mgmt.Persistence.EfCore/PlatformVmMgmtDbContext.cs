using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Platform.Vm.Mgmt.Domain.Common;

namespace Platform.Vm.Mgmt.Persistence.EfCore
{
    public class PlatformVmMgmtDbContext : DbContext
    {
        public PlatformVmMgmtDbContext(DbContextOptions<PlatformVmMgmtDbContext> options)
            : base(options) { }

        public DbSet<Domain.Entities.VmOrderDetail> VmOrderDetails { get; set; }
        public DbSet<Domain.Entities.VmOrder> VmOrders { get; set; }


        public DbSet<Domain.Entities.VmSize> VmSizes { get; set; }
        public DbSet<Domain.Entities.VmType> VmTypes { get; set; }
        public DbSet<Domain.Entities.TimeZone> TimeZones { get; set; }

        public DbSet<Domain.Entities.Vlan> Vlans { get; set; }
        public DbSet<Domain.Entities.Environment> Environments { get; set; }
        public DbSet<Domain.Entities.DataCentre> DataCentres { get; set; }


        private readonly Guid VmSizeSmall = Guid.Parse("{A1B74577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid VmSizeMedium = Guid.Parse("{A2B74577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid VmSizeLarge = Guid.Parse("{A3B74577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid VmSizeGigantic = Guid.Parse("{A4B74577-1C93-4D83-A160-D0C100B75C0C}");

        private readonly Guid VmTypeRhel8 = Guid.Parse("{A1B64577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid VmTypeRhel9 = Guid.Parse("{A2B64577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid VmTypeRhel10 = Guid.Parse("{A3B64577-1C93-4D83-A160-D0C100B75C0C}");

        private readonly Guid TimeZoneEuropeLondon = Guid.Parse("{A1B54577-1C93-4D83-A160-D0C100B75C0C}");


        //private readonly Guid Vlan0Guid = Guid.Parse("{000D0837-E1E4-4078-8DA3-9F62A4C33C58}");   //NO! - DEPRECIATED - DO NOT USE

        private readonly Guid Vlan113Guid = Guid.Parse("{113D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN in DEV
        private readonly Guid Vlan155Guid = Guid.Parse("{155D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN in UAT
        //private readonly Guid Vlan156Guid = Guid.Parse("{156D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN in CERT - Not Needed ?

        //private readonly Guid Vlan450Guid = Guid.Parse("{450D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN for HVMON-SH - Not Needed ?
        //private readonly Guid Vlan451Guid = Guid.Parse("{451D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN for HVMON-PG - Not Needed ?

        private readonly Guid Vlan600Guid = Guid.Parse("{600D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN in PROD
        //private readonly Guid Vlan601Guid = Guid.Parse("{601D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN for PG APP Servers - PG - Not Needed ?
        //private readonly Guid Vlan602Guid = Guid.Parse("{602D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN for AZDO Agents - PG - Not Needed ?
        //private readonly Guid Vlan607Guid = Guid.Parse("{607D0837-E1E4-4078-8DA3-9F62A4C33C58}"); //VLAN for SH APP Servers - SH - Not Needed ?


        private readonly Guid EnvDevGuid = Guid.Parse("{E1B64577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid EnvOatGuid = Guid.Parse("{E2B64577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid EnvUatGuid = Guid.Parse("{E3B64577-1C93-4D83-A160-D0C100B75C0C}");
        private readonly Guid EnvProdGuid = Guid.Parse("{E4B64577-1C93-4D83-A160-D0C100B75C0C}");

        private readonly Guid DcShGuid = Guid.Parse("{D18519B3-4B35-4D5A-8720-2593881615E5}");
        private readonly Guid DcPgGuid = Guid.Parse("{D28519B3-4B35-4D5A-8720-2593881615E5}");
        private readonly Guid DcMa4Guid = Guid.Parse("{D38519B3-4B35-4D5A-8720-2593881615E5}");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlatformVmMgmtDbContext).Assembly);

            //Seed DC's
            SeedDataCentres(modelBuilder);
            //Seed Env's
            SeedEnvironments(modelBuilder);
            //Seed VLAN's
            SeedVlans(modelBuilder);


            //Seed VM Sizes
            SeedVmSizes(modelBuilder);
            //Seed VM Types
            SeedVmTypes(modelBuilder);
            //Seed TimeZones
            SeedTimeZones(modelBuilder);

            //Seed VM Orders
            SeedVmOrders(modelBuilder);
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

        private void SeedVmOrders(ModelBuilder model)
        {
            model.Entity<Domain.Entities.VmOrder>().HasData(new Domain.Entities.VmOrder
            {
                Id = Guid.Parse("{A1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                Name = "Apache Focus in Dev",
                Description = "VM Order - 3 Small RHEL 8 VMs for Apache Focus",
                VmOrderPlaced = new DateTime(2025, 03, 12),
                EnvironmentId = EnvDevGuid,
                TimeZoneId = TimeZoneEuropeLondon,
                PrimaryContactName = "John Doe",
                PrimaryContactEmail = "john.doe@email.com",
                TeamName = "Apache Focus Team"
            });
            model.Entity<Domain.Entities.VmOrderDetail>().HasData(new Domain.Entities.VmOrderDetail
            {
                Id = Guid.Parse("{B1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmOrderId = Guid.Parse("{A1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmTypeId = VmTypeRhel8,
                VmSizeId = VmSizeSmall
            });
            model.Entity<Domain.Entities.VmOrderDetail>().HasData(new Domain.Entities.VmOrderDetail
            {
                Id = Guid.Parse("{B2B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmOrderId = Guid.Parse("{A1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmTypeId = VmTypeRhel8,
                VmSizeId = VmSizeSmall
            });
            model.Entity<Domain.Entities.VmOrderDetail>().HasData(new Domain.Entities.VmOrderDetail
            {
                Id = Guid.Parse("{B3B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmOrderId = Guid.Parse("{A1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmTypeId = VmTypeRhel8,
                VmSizeId = VmSizeSmall
            });


            model.Entity<Domain.Entities.VmOrder>().HasData(new Domain.Entities.VmOrder
            {
                Id = Guid.Parse("{B1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                Name = "Apache Delta in Dev",
                Description = "VM Order - 2 Medium RHEL 9 VMs for Apache Delta",
                VmOrderPlaced = new DateTime(2025, 03, 15),
                EnvironmentId = EnvDevGuid,
                TimeZoneId = TimeZoneEuropeLondon,
                PrimaryContactName = "Jane Doe",
                PrimaryContactEmail = "jane.doe@email.com",
                TeamName = "Apache Delta Team"
            });
            model.Entity<Domain.Entities.VmOrderDetail>().HasData(new Domain.Entities.VmOrderDetail
            {
                Id = Guid.Parse("{C1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmOrderId = Guid.Parse("{B1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmTypeId = VmTypeRhel9,
                VmSizeId = VmSizeMedium
            });
            model.Entity<Domain.Entities.VmOrderDetail>().HasData(new Domain.Entities.VmOrderDetail
            {
                Id = Guid.Parse("{C2B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmOrderId = Guid.Parse("{B1B64577-1C93-4D83-A160-D0C100B75C0C}"),
                VmTypeId = VmTypeRhel9,
                VmSizeId = VmSizeMedium
            });
        }

        private void SeedVmTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.VmType>().HasData(new Domain.Entities.VmType
            {
                Id = VmTypeRhel8,
                Name = "RHEL 8",
                Description = "Red Hat Enterprise 8",
                IsEnabled = true,
                Sequence = 1,

                OsType = "RHEL",
                OsVersion = "8"
            });
            modelBuilder.Entity<Domain.Entities.VmType>().HasData(new Domain.Entities.VmType
            {
                Id = VmTypeRhel9,
                Name = "RHEL 9",
                Description = "Red Hat Enterprise 9",
                IsEnabled = true,
                Sequence = 2,

                OsType = "RHEL",
                OsVersion = "9"
            });
            modelBuilder.Entity<Domain.Entities.VmType>().HasData(new Domain.Entities.VmType
            {
                Id = VmTypeRhel10,
                Name = "RHEL 10",
                Description = "Red Hat Enterprise 10",
                IsEnabled = false,
                Sequence = 3,

                OsType = "RHEL",
                OsVersion = "10"
            });
        }

        private void SeedVmSizes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.VmSize>().HasData(new Domain.Entities.VmSize
            {
                Id = VmSizeSmall,
                Name = "Small",
                Description = "Small VM Size",
                IsEnabled = true,
                Sequence = 1,

                CpuCount = 2,
                RamGb = 4,
                HddGb = 10
            });
            modelBuilder.Entity<Domain.Entities.VmSize>().HasData(new Domain.Entities.VmSize
            {
                Id = VmSizeMedium,
                Name = "Medium",
                Description = "Medium VM Size",
                IsEnabled = true,
                Sequence= 2,

                CpuCount = 4,
                RamGb = 8,
                HddGb = 20
            });
            modelBuilder.Entity<Domain.Entities.VmSize>().HasData(new Domain.Entities.VmSize
            {
                Id = VmSizeLarge,
                Name = "Large",
                Description = "Large VM Size",
                IsEnabled = true,
                Sequence = 3,

                CpuCount = 8,
                RamGb = 16,
                HddGb = 40
            });
            modelBuilder.Entity<Domain.Entities.VmSize>().HasData(new Domain.Entities.VmSize
            {
                Id = VmSizeGigantic,
                Name = "Gigantic",
                Description = "Gigantic VM Size",
                IsEnabled = false,
                Sequence = 4,

                CpuCount = 64,
                RamGb = 256,
                HddGb = 500
            });
        }

        private void SeedTimeZones(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.TimeZone>().HasData(new Domain.Entities.TimeZone
            {
                Id = TimeZoneEuropeLondon,
                Name = "Europe/London",
                Description = "Europe/London",
                IsEnabled = true,
                Sequence = 1,

                Code = "GMT"
            });
        }


        private void SeedVlans(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Vlan>().HasData(new Domain.Entities.Vlan
            {
                Id = Vlan113Guid,
                Name = "VLAN113",
                Description = "VLAN in DEV",
                IsEnabled = true,
                Sequence = 1,

                EnvironmentId = EnvDevGuid
            });

            modelBuilder.Entity<Domain.Entities.Vlan>().HasData(new Domain.Entities.Vlan
            {
                Id = Vlan155Guid,
                Name = "VLAN155",
                Description = "VLAN in UAT",
                IsEnabled = true,
                Sequence = 3,

                EnvironmentId = EnvUatGuid
            });

            modelBuilder.Entity<Domain.Entities.Vlan>().HasData(new Domain.Entities.Vlan
            {
                Id = Vlan600Guid,
                Name = "VLAN600",
                Description = "VLAN in PROD",
                IsEnabled = true,
                Sequence = 4,

                EnvironmentId = EnvProdGuid
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
                Sequence = 1,

                Tier = 4,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvOatGuid,
                Name = "Operational Acceptance Testing",
                Description = "Provides the environment for operational acceptance testing, including failover and performance testing.",
                IsEnabled = true,
                Sequence = 2,

                Tier = 3,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvUatGuid,
                Name = "User Acceptance Testing",
                Description = "Final verification testing for software changes from customer end-users.",
                IsEnabled = true,
                Sequence = 3,

                Tier = 2,

                DataCentreId = DcPgGuid
            });

            modelBuilder.Entity<Domain.Entities.Environment>().HasData(new Domain.Entities.Environment
            {
                Id = EnvProdGuid,
                Name = "Production Systems",
                Description = "Live operational environment at the very highest level of isolation. This houses the services that customers pay to use at a 99.9% availability SLA.",
                IsEnabled = true,
                Sequence = 4,

                Tier = 1,

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
                Sequence = 1,
                Location = "London, UK"
            });

            modelBuilder.Entity<Domain.Entities.DataCentre>().HasData(new Domain.Entities.DataCentre
            {
                Id = DcPgGuid,
                Name = "Power Gate",
                Description = "Secondary DC",
                IsEnabled = true,
                Sequence = 2,
                Location = "London, UK"
            });

            modelBuilder.Entity<Domain.Entities.DataCentre>().HasData(new Domain.Entities.DataCentre
            {
                Id = DcMa4Guid,
                Name = "MA-4",
                Description = "DC in the North",
                IsEnabled = true,
                Sequence = 3,
                Location = "Manchester, UK"
            });
        }
    }
}