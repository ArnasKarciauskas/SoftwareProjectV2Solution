using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareProjectV2.Data.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddDetailAddEquipment");

            migrationBuilder.AlterColumn<string>(
                name: "InvDeviceType",
                table: "Inventory",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "InvDeviceName",
                table: "Inventory",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceType",
                table: "AddEquipment",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "AddEquipment",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddDetailDetailId",
                table: "AddEquipment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddEquipment_AddDetailDetailId",
                table: "AddEquipment",
                column: "AddDetailDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddEquipment_AddDetail_AddDetailDetailId",
                table: "AddEquipment",
                column: "AddDetailDetailId",
                principalTable: "AddDetail",
                principalColumn: "DetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddEquipment_AddDetail_AddDetailDetailId",
                table: "AddEquipment");

            migrationBuilder.DropIndex(
                name: "IX_AddEquipment_AddDetailDetailId",
                table: "AddEquipment");

            migrationBuilder.DropColumn(
                name: "AddDetailDetailId",
                table: "AddEquipment");

            migrationBuilder.AlterColumn<string>(
                name: "InvDeviceType",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "InvDeviceName",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceType",
                table: "AddEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "AddEquipment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

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
    }
}
