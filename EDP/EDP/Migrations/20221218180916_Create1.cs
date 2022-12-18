using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDP.Migrations
{
    /// <inheritdoc />
    public partial class Create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    cartid = table.Column<string>(name: "cart_id", type: "nvarchar(450)", nullable: false),
                    productid = table.Column<string>(name: "product_id", type: "nvarchar(max)", nullable: false),
                    userid = table.Column<string>(name: "user_id", type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.cartid);
                });

            migrationBuilder.CreateTable(
                name: "ClaimedVouchers",
                columns: table => new
                {
                    claimedvoucherid = table.Column<string>(name: "claimed_voucher_id", type: "nvarchar(450)", nullable: false),
                    userid = table.Column<string>(name: "user_id", type: "nvarchar(max)", nullable: false),
                    voucherid = table.Column<string>(name: "voucher_id", type: "nvarchar(max)", nullable: false),
                    vouchercode = table.Column<string>(name: "voucher_code", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimedVouchers", x => x.claimedvoucherid);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedItems",
                columns: table => new
                {
                    purchaseditemid = table.Column<string>(name: "purchased_item_id", type: "nvarchar(450)", nullable: false),
                    productname = table.Column<string>(name: "product_name", type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    purchasehistoryid = table.Column<string>(name: "purchase_history_id", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedItems", x => x.purchaseditemid);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseHistories",
                columns: table => new
                {
                    purchasehistoryid = table.Column<string>(name: "purchase_history_id", type: "nvarchar(450)", nullable: false),
                    totalprice = table.Column<decimal>(name: "total_price", type: "decimal(18,2)", nullable: false),
                    purchasedate = table.Column<DateTime>(name: "purchase_date", type: "datetime2", nullable: false),
                    discountedprice = table.Column<decimal>(name: "discounted_price", type: "decimal(18,2)", nullable: false),
                    paymentreferencecode = table.Column<string>(name: "payment_reference_code", type: "nvarchar(max)", nullable: false),
                    vouchername = table.Column<string>(name: "voucher_name", type: "nvarchar(max)", nullable: false),
                    percentageoff = table.Column<string>(name: "percentage_off", type: "nvarchar(max)", nullable: false),
                    userid = table.Column<string>(name: "user_id", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseHistories", x => x.purchasehistoryid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ClaimedVouchers");

            migrationBuilder.DropTable(
                name: "PurchasedItems");

            migrationBuilder.DropTable(
                name: "PurchaseHistories");
        }
    }
}
