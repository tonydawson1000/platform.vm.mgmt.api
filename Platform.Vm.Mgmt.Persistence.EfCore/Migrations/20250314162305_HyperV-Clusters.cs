using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Platform.Vm.Mgmt.Persistence.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class HyperVClusters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HyperVClusters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperVClusters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HyperVNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    HostName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HyperVClusterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCentreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperVNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HyperVNodes_DataCentres_DataCentreId",
                        column: x => x.DataCentreId,
                        principalTable: "DataCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HyperVNodes_HyperVClusters_HyperVClusterId",
                        column: x => x.HyperVClusterId,
                        principalTable: "HyperVClusters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HyperVClusters",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HyperV Cluster - HostGroups - PGDevServers", null, null, "PG Dev Servers" },
                    { new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", null, null, "PG App Servers" },
                    { new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", null, null, "SH Prod Servers" }
                });

            migrationBuilder.InsertData(
                table: "HyperVNodes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DataCentreId", "Description", "HostName", "HyperVClusterId", "IsEnabled", "LastModifiedBy", "LastModifiedDate", "Name", "Sequence" },
                values: new object[,]
                {
                    { new Guid("a1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", "HVAPPPG01", new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPPG01", 1 },
                    { new Guid("a2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", "HVAPPPG02", new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPPG02", 2 },
                    { new Guid("a3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", "HVAPPPG03", new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPPG03", 3 },
                    { new Guid("a4b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", "HVAPPPG04", new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPPG04", 4 },
                    { new Guid("a5b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - App/UAT/CERT/AZDO Servers", "HVAPPPG05", new Guid("c2b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPPG05", 5 },
                    { new Guid("b1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH01", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH01", 1 },
                    { new Guid("b2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH02", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH02", 2 },
                    { new Guid("b3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH03", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH03", 3 },
                    { new Guid("b4b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH04", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH04", 4 },
                    { new Guid("b5b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH05", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH05", 5 },
                    { new Guid("b6b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d18519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PRODTMC/MMSSH/SHTechOps Servers", "HVAPPSH06", new Guid("c3b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVAPPSH06", 6 },
                    { new Guid("e1b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG01", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG01", 1 },
                    { new Guid("e2b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG02", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG02", 2 },
                    { new Guid("e3b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG03", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG03", 3 },
                    { new Guid("e4b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG04", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG04", 4 },
                    { new Guid("e5b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG05", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG05", 5 },
                    { new Guid("e6b64577-1c93-4d83-a160-d0c100b75c0c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d28519b3-4b35-4d5a-8720-2593881615e5"), "HyperV Node - HyperV Cluster - HostGroups - PGDevServers", "HVDEVPG06", new Guid("c1b64577-1c93-4d83-a160-d0c100b75c0c"), true, null, null, "HVDEVPG06", 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HyperVNodes_DataCentreId",
                table: "HyperVNodes",
                column: "DataCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperVNodes_HyperVClusterId",
                table: "HyperVNodes",
                column: "HyperVClusterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HyperVNodes");

            migrationBuilder.DropTable(
                name: "HyperVClusters");
        }
    }
}