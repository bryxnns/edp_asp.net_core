using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    /// <inheritdoc />
    public partial class Create3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "PurchaseHistories",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ClaimedVouchers",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Carts",
                newName: "User_ID");

            migrationBuilder.CreateTable(
                name: "DonationDetails",
                columns: table => new
                {
                    wasteweight = table.Column<string>(name: "waste_weight", type: "nvarchar(max)", nullable: false),
                    wasteimage = table.Column<string>(name: "waste_image", type: "nvarchar(max)", nullable: false),
                    collectiondone = table.Column<bool>(name: "collection_done", type: "bit", nullable: false),
                    dropoffdone = table.Column<bool>(name: "drop_off_done", type: "bit", nullable: false),
                    dropoffpoint = table.Column<string>(name: "drop_off_point", type: "nvarchar(max)", nullable: false),
                    userdonationid = table.Column<string>(name: "user_donation_id", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productid = table.Column<string>(name: "product_id", type: "nvarchar(450)", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    expirydate = table.Column<string>(name: "expiry_date", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productid);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    reviewid = table.Column<string>(name: "review_id", type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(name: "User_ID", type: "nvarchar(max)", nullable: false),
                    productid = table.Column<string>(name: "product_id", type: "nvarchar(max)", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.reviewid);
                });

            migrationBuilder.CreateTable(
                name: "UserDonations",
                columns: table => new
                {
                    userdonationid = table.Column<string>(name: "user_donation_id", type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitno = table.Column<string>(name: "unit_no", type: "nvarchar(max)", nullable: false),
                    postalcode = table.Column<int>(name: "postal_code", type: "int", nullable: false),
                    collectiondate = table.Column<string>(name: "collection_date", type: "nvarchar(max)", nullable: false),
                    collectiontime = table.Column<string>(name: "collection_time", type: "nvarchar(max)", nullable: false),
                    typeofwaste = table.Column<string>(name: "type_of_waste", type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(name: "User_ID", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDonations", x => x.userdonationid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserDonations");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "PurchaseHistories",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "ClaimedVouchers",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Carts",
                newName: "user_id");
        }
    }
}
