using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Platform.Vm.Mgmt.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataCentres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCentres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    DataCentreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Environments_DataCentres_DataCentreId",
                        column: x => x.DataCentreId,
                        principalTable: "DataCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: true),
                    EnvironmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vlans_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataCentres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary DC", true, null, null, "London, UK", "Sov House" },
                    { new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secondary DC", true, null, null, "London, UK", "Power Gate" },
                    { new Guid("d38519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DC in the North", true, null, null, "Manchester, UK", "MA-4" }
                });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataCentreId", "Description", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "Sequence", "Tier" },
                values: new object[,]
                {
                    { new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "Houses resources required for development purposes, including (but not limited to) day-to-day development, automated integration (INT) testing, systems integration testing (SIT), internal demos.", true, null, null, "Development", 1, 4 },
                    { new Guid("e2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "Provides the environment for operational acceptance testing, including failover and performance testing.", true, null, null, "Operational Acceptance Testing", 2, 3 },
                    { new Guid("e3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "Final verification testing for software changes from customer end-users.", true, null, null, "User Acceptance Testing", 3, 2 },
                    { new Guid("e4b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "Live operational environment at the very highest level of isolation. This houses the services that customers pay to use at a 99.9% availability SLA.", true, null, null, "Production Systems", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vlans",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "EnvironmentId", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { new Guid("113d0837-e1e4-4078-8da3-9f62a4c33c58"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NEW VLAN in ML for DEV Deployments of VMs ...", new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "ML-DEV-PG" });

            migrationBuilder.CreateIndex(
                name: "IX_Environments_DataCentreId",
                table: "Environments",
                column: "DataCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlans_EnvironmentId",
                table: "Vlans",
                column: "EnvironmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vlans");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "DataCentres");
        }
    }
}