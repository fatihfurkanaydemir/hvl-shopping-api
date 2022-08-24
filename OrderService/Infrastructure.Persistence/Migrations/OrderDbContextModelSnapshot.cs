﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderService.Infrastructure.Persistence.Contexts;

#nullable disable

namespace OrderService.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    partial class OrderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Common.Entities.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PricePerProduct")
                        .HasColumnType("numeric(18,6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("OrderService.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CheckoutSessionId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CheckoutSessionUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("CouponAmount")
                        .HasColumnType("numeric(18,6)");

                    b.Property<string>("CouponCode")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerIdentityId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderGroupId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PaymentIntentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SellerIdentityId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ShipmentPrice")
                        .HasColumnType("numeric(18,6)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalProductPrice")
                        .HasColumnType("numeric(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Common.Entities.OrderProduct", b =>
                {
                    b.HasOne("OrderService.Domain.Entities.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("OrderService.Domain.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
