using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationDetails");

            migrationBuilder.DropTable(
                name: "UserDonations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationDetails",
                columns: table => new
                {
                    user_donation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    collection_done = table.Column<bool>(type: "bit", nullable: false),
                    drop_off_done = table.Column<bool>(type: "bit", nullable: false),
                    drop_off_point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waste_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waste_weight = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationDetails", x => x.user_donation_id);
                });

            migrationBuilder.CreateTable(
                name: "UserDonations",
                columns: table => new
                {
                    user_donation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    collection_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    collection_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_of_waste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDonations", x => x.user_donation_id);
                });
        }
    }
}
