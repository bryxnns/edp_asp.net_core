﻿// <auto-generated />
using System;
using EDP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EDP.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EDP.Models.Cart", b =>
                {
                    b.Property<string>("cart_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("cart_id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("EDP.Models.Claimed_Voucher", b =>
                {
                    b.Property<string>("claimed_voucher_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("voucher_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("voucher_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("claimed_voucher_id");

                    b.ToTable("ClaimedVouchers");
                });

            modelBuilder.Entity("EDP.Models.Donation_Details", b =>
                {
                    b.Property<bool>("collection_done")
                        .HasColumnType("bit");

                    b.Property<bool>("drop_off_done")
                        .HasColumnType("bit");

                    b.Property<string>("drop_off_point")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_donation_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("waste_image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("waste_weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("DonationDetails");
                });

            modelBuilder.Entity("EDP.Models.Products", b =>
                {
                    b.Property<string>("product_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("expiry_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EDP.Models.Purchase_History", b =>
                {
                    b.Property<string>("purchase_history_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("discounted_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("payment_reference_code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("percentage_off")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("purchase_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("total_price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("voucher_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("purchase_history_id");

                    b.ToTable("PurchaseHistories");
                });

            modelBuilder.Entity("EDP.Models.Purchased_Item", b =>
                {
                    b.Property<string>("purchased_item_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("purchase_history_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("purchased_item_id");

                    b.ToTable("PurchasedItems");
                });

            modelBuilder.Entity("EDP.Models.Reviews", b =>
                {
                    b.Property<string>("review_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("product_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("review_id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EDP.Models.User_Donation", b =>
                {
                    b.Property<string>("user_donation_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("collection_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("collection_time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("postal_code")
                        .HasColumnType("int");

                    b.Property<string>("type_of_waste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unit_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_donation_id");

                    b.ToTable("UserDonations");
                });

            modelBuilder.Entity("EDP.Models.Voucher", b =>
                {
                    b.Property<string>("voucher_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("expiry_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("percentage_off")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("points_required")
                        .HasColumnType("int");

                    b.Property<string>("voucher_name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("voucher_id");

                    b.ToTable("Vouchers");
                });
#pragma warning restore 612, 618
        }
    }
}
