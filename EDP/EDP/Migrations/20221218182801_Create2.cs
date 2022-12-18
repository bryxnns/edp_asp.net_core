using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    /// <inheritdoc />
    public partial class Create2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    voucherid = table.Column<string>(name: "voucher_id", type: "nvarchar(450)", nullable: false),
                    vouchername = table.Column<string>(name: "voucher_name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    percentageoff = table.Column<string>(name: "percentage_off", type: "nvarchar(max)", nullable: false),
                    pointsrequired = table.Column<int>(name: "points_required", type: "int", nullable: false),
                    expirydate = table.Column<DateTime>(name: "expiry_date", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.voucherid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
