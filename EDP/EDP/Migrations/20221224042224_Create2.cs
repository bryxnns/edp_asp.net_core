using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    public partial class Create2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "min_spend",
                table: "Vouchers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "min_spend",
                table: "Vouchers");
        }
    }
}
