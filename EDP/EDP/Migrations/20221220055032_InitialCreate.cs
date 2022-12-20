using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cart_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimedVouchers",
                columns: table => new
                {
                    claimed_voucher_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucher_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucher_code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimedVouchers", x => x.claimed_voucher_id);
                });

            migrationBuilder.CreateTable(
                name: "DonationDetails",
                columns: table => new
                {
                    waste_weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    waste_image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    collection_done = table.Column<bool>(type: "bit", nullable: false),
                    drop_off_done = table.Column<bool>(type: "bit", nullable: false),
                    drop_off_point = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_donation_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    expiry_date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedItems",
                columns: table => new
                {
                    purchased_item_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    purchase_history_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedItems", x => x.purchased_item_id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistories",
                columns: table => new
                {
                    purchase_history_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    purchase_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    discounted_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    payment_reference_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    percentage_off = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistories", x => x.purchase_history_id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    review_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.review_id);
                });

            migrationBuilder.CreateTable(
                name: "UserDonations",
                columns: table => new
                {
                    user_donation_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_code = table.Column<int>(type: "int", nullable: false),
                    collection_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    collection_time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_of_waste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDonations", x => x.user_donation_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unit_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postal_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    voucher_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    voucher_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    percentage_off = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    points_required = table.Column<int>(type: "int", nullable: false),
                    expiry_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.voucher_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ClaimedVouchers");

            migrationBuilder.DropTable(
                name: "DonationDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchasedItems");

            migrationBuilder.DropTable(
                name: "PurchaseHistories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserDonations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vouchers");
        }
    }
}
