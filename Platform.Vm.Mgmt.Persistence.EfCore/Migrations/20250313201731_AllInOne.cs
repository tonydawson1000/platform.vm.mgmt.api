using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Platform.Vm.Mgmt.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AllInOne : Migration
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
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
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
                name: "TimeZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VmSizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    CpuCount = table.Column<int>(type: "int", nullable: false),
                    RamGb = table.Column<int>(type: "int", nullable: false),
                    HddGb = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VmSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VmTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    OsType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OsVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VmTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
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
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "VmOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VmOrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnvironmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimaryContactEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VmOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VmOrders_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VmOrders_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VmOrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VmOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VmTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VmSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VmOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VmOrderDetails_VmOrders_VmOrderId",
                        column: x => x.VmOrderId,
                        principalTable: "VmOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VmOrderDetails_VmSizes_VmSizeId",
                        column: x => x.VmSizeId,
                        principalTable: "VmSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VmOrderDetails_VmTypes_VmTypeId",
                        column: x => x.VmTypeId,
                        principalTable: "VmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataCentres",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Location", "Name", "Sequence" },
                values: new object[,]
                {
                    { new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary DC", true, null, null, "London, UK", "Sov House", 1 },
                    { new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secondary DC", true, null, null, "London, UK", "Power Gate", 2 },
                    { new Guid("d38519b3-4b35-4d5a-8720-2593881615e5"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DC in the North", true, null, null, "Manchester, UK", "MA-4", 3 }
                });

            migrationBuilder.InsertData(
                table: "TimeZones",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "Sequence" },
                values: new object[] { new Guid("a1b54577-1c93-4d83-a160-d0c100b75c0c"), "GMT", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Europe/London", true, null, null, "Europe/London", 1 });

            migrationBuilder.InsertData(
                table: "VmSizes",
                columns: new[] { "Id", "CpuCount", "CreatedBy", "CreatedDate", "Description", "HddGb", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "RamGb", "Sequence" },
                values: new object[,]
                {
                    { new Guid("a1b74577-1c93-4d83-a160-d0c100b75c0c"), 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Small VM Size", 10, true, null, null, "Small", 4, 1 },
                    { new Guid("a2b74577-1c93-4d83-a160-d0c100b75c0c"), 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medium VM Size", 20, true, null, null, "Medium", 8, 2 },
                    { new Guid("a3b74577-1c93-4d83-a160-d0c100b75c0c"), 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Large VM Size", 40, true, null, null, "Large", 16, 3 },
                    { new Guid("a4b74577-1c93-4d83-a160-d0c100b75c0c"), 64, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gigantic VM Size", 500, false, null, null, "Gigantic", 256, 4 }
                });

            migrationBuilder.InsertData(
                table: "VmTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "OsType", "OsVersion", "Sequence" },
                values: new object[,]
                {
                    { new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Hat Enterprise 8", true, null, null, "RHEL 8", "RHEL", "8", 1 },
                    { new Guid("a2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Hat Enterprise 9", true, null, null, "RHEL 9", "RHEL", "9", 2 },
                    { new Guid("a3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Hat Enterprise 10", false, null, null, "RHEL 10", "RHEL", "10", 3 }
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
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "EnvironmentId", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "Sequence" },
                values: new object[,]
                {
                    { new Guid("113d0837-e1e4-4078-8da3-9f62a4c33c58"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VLAN in DEV", new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "VLAN113", 1 },
                    { new Guid("155d0837-e1e4-4078-8da3-9f62a4c33c58"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VLAN in UAT", new Guid("e3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "VLAN155", 3 },
                    { new Guid("600d0837-e1e4-4078-8da3-9f62a4c33c58"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VLAN in PROD", new Guid("e4b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "VLAN600", 4 }
                });

            migrationBuilder.InsertData(
                table: "VmOrders",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "EnvironmentId", "LastModifiedBy", "LastModifiedDate", "Name", "PrimaryContactEmail", "PrimaryContactName", "TeamName", "TimeZoneId", "VmOrderPlaced" },
                values: new object[,]
                {
                    { new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VM Order - 3 Small RHEL 8 VMs for Apache Focus", new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), null, null, "Apache Focus in Dev", "john.doe@email.com", "John Doe", "Apache Focus Team", new Guid("a1b54577-1c93-4d83-a160-d0c100b75c0c"), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VM Order - 2 Medium RHEL 9 VMs for Apache Delta", new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), null, null, "Apache Delta in Dev", "jane.doe@email.com", "Jane Doe", "Apache Delta Team", new Guid("a1b54577-1c93-4d83-a160-d0c100b75c0c"), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VmOrderDetails",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "VmOrderId", "VmSizeId", "VmTypeId" },
                values: new object[,]
                {
                    { new Guid("b1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b74577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c") },
                    { new Guid("b2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b74577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c") },
                    { new Guid("b3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b74577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c") },
                    { new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b1b64577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a2b74577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a2b64577-1c93-4d83-a160-d0c100b75c0c") },
                    { new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new Guid("b1b64577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a2b74577-1c93-4d83-a160-d0c100b75c0c"), new Guid("a2b64577-1c93-4d83-a160-d0c100b75c0c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Environments_DataCentreId",
                table: "Environments",
                column: "DataCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlans_EnvironmentId",
                table: "Vlans",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VmOrderDetails_VmOrderId",
                table: "VmOrderDetails",
                column: "VmOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_VmOrderDetails_VmSizeId",
                table: "VmOrderDetails",
                column: "VmSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_VmOrderDetails_VmTypeId",
                table: "VmOrderDetails",
                column: "VmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VmOrders_EnvironmentId",
                table: "VmOrders",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VmOrders_TimeZoneId",
                table: "VmOrders",
                column: "TimeZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vlans");

            migrationBuilder.DropTable(
                name: "VmOrderDetails");

            migrationBuilder.DropTable(
                name: "VmOrders");

            migrationBuilder.DropTable(
                name: "VmSizes");

            migrationBuilder.DropTable(
                name: "VmTypes");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "DataCentres");
        }
    }
}