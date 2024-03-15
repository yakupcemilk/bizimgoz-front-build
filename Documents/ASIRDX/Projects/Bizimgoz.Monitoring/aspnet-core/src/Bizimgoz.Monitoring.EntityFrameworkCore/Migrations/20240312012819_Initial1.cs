using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bizimgoz.Monitoring.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardPosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    Purpose = table.Column<string>(type: "text", nullable: false),
                    Options = table.Column<List<string>>(type: "text[]", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Hostid = table.Column<string>(type: "text", nullable: false),
                    HostName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Flags = table.Column<int>(type: "integer", nullable: false),
                    InventoryMode = table.Column<int>(type: "integer", nullable: false),
                    IpmiAuthtype = table.Column<int>(type: "integer", nullable: false),
                    IpmiPassword = table.Column<string>(type: "text", nullable: false),
                    IpmiPrivilege = table.Column<int>(type: "integer", nullable: false),
                    IpmiUsername = table.Column<string>(type: "text", nullable: false),
                    MaintenanceFrom = table.Column<string>(type: "text", nullable: false),
                    MaintenanceStatus = table.Column<int>(type: "integer", nullable: false),
                    MaintenanceType = table.Column<int>(type: "integer", nullable: false),
                    Maintenanceid = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProxyHostid = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TlsConnect = table.Column<int>(type: "integer", nullable: false),
                    TlsAccept = table.Column<int>(type: "integer", nullable: false),
                    TlsIssuer = table.Column<string>(type: "text", nullable: false),
                    TlsSubject = table.Column<string>(type: "text", nullable: false),
                    TlsPskIdentity = table.Column<string>(type: "text", nullable: true),
                    TlsPsk = table.Column<string>(type: "text", nullable: true),
                    ActiveAvailable = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NodePosition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    X = table.Column<float>(type: "real", nullable: false),
                    Y = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NodePosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Widgets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HostId = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    Serial = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Uptime = table.Column<string>(type: "text", nullable: false),
                    CpuItemId = table.Column<string>(type: "text", nullable: false),
                    RamItemId = table.Column<string>(type: "text", nullable: false),
                    DiskItemId = table.Column<string>(type: "text", nullable: false),
                    WanInterfaceTrafficIds = table.Column<List<string>>(type: "text[]", nullable: false),
                    InterfacePortTrafficIds = table.Column<List<string>>(type: "text[]", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZabbixInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZabbixInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DashboardId = table.Column<Guid>(type: "uuid", nullable: false),
                    hostid = table.Column<string>(type: "text", nullable: false),
                    GraphType = table.Column<string>(type: "text", nullable: false),
                    itemids = table.Column<List<string>>(type: "text[]", nullable: false),
                    SizeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardElements_DashboardPosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "DashboardPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardElements_DashboardSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "DashboardSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashboardElements_Dashboards_DashboardId",
                        column: x => x.DashboardId,
                        principalTable: "Dashboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopologyNodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    HostId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DeviceType = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopologyNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopologyNodes_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopologyNodes_NodePosition_PositionId",
                        column: x => x.PositionId,
                        principalTable: "NodePosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopologyEdges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopologyEdges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopologyEdges_TopologyNodes_SourceId",
                        column: x => x.SourceId,
                        principalTable: "TopologyNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopologyEdges_TopologyNodes_TargetId",
                        column: x => x.TargetId,
                        principalTable: "TopologyNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardElements_DashboardId",
                table: "DashboardElements",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardElements_PositionId",
                table: "DashboardElements",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_DashboardElements_SizeId",
                table: "DashboardElements",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopologyEdges_SourceId",
                table: "TopologyEdges",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TopologyEdges_TargetId",
                table: "TopologyEdges",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_TopologyNodes_HostId",
                table: "TopologyNodes",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_TopologyNodes_PositionId",
                table: "TopologyNodes",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardElements");

            migrationBuilder.DropTable(
                name: "TelegramUsers");

            migrationBuilder.DropTable(
                name: "TopologyEdges");

            migrationBuilder.DropTable(
                name: "Widgets");

            migrationBuilder.DropTable(
                name: "ZabbixInformations");

            migrationBuilder.DropTable(
                name: "DashboardPosition");

            migrationBuilder.DropTable(
                name: "DashboardSize");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "TopologyNodes");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "NodePosition");
        }
    }
}
