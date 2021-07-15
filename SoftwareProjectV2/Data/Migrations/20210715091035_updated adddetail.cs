using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareProjectV2.Data.Migrations
{
    public partial class updatedadddetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeNumber",
                table: "AddDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeNumber",
                table: "AddDetail");
        }
    }
}
