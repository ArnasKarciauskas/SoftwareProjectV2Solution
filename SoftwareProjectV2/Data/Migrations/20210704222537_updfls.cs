using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareProjectV2.Data.Migrations
{
    public partial class updfls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddDetail",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeSecondName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeePPS = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    EmployeeStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDetail", x => x.DetailId);
                });

            migrationBuilder.CreateTable(
                name: "AddEquipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddEquipment", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "AddDetailAddEquipment",
                columns: table => new
                {
                    AddEquipmentsEquipmentId = table.Column<int>(type: "int", nullable: false),
                    _AddDetailsICDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDetailAddEquipment", x => new { x.AddEquipmentsEquipmentId, x._AddDetailsICDetailId });
                    table.ForeignKey(
                        name: "FK_AddDetailAddEquipment_AddDetail__AddDetailsICDetailId",
                        column: x => x._AddDetailsICDetailId,
                        principalTable: "AddDetail",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddDetailAddEquipment_AddEquipment_AddEquipmentsEquipmentId",
                        column: x => x.AddEquipmentsEquipmentId,
                        principalTable: "AddEquipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddDetailAddEquipment__AddDetailsICDetailId",
                table: "AddDetailAddEquipment",
                column: "_AddDetailsICDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddDetailAddEquipment");

            migrationBuilder.DropTable(
                name: "AddDetail");

            migrationBuilder.DropTable(
                name: "AddEquipment");
        }
    }
}
