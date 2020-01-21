﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using restful_api.Database;

namespace restful_api.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20200121073444_AddForeignKeyinEachTable")]
    partial class AddForeignKeyinEachTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("restful_api.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("restful_api.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("restful_api.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("delivery_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("delivery_id");

                    b.ToTable("DeliveryAddresses");
                });

            modelBuilder.Entity("restful_api.Models.Login", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<string>("pasword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.HasIndex("customer_id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("restful_api.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<int>("delivery_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("customer_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("restful_api.Models.OrderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("order_id");

                    b.HasIndex("product_id");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("restful_api.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("cat_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cat_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("restful_api.Models.DeliveryAddress", b =>
                {
                    b.HasOne("restful_api.Models.DeliveryAddress", null)
                        .WithMany("DeliveryAddresses")
                        .HasForeignKey("delivery_id");
                });

            modelBuilder.Entity("restful_api.Models.Login", b =>
                {
                    b.HasOne("restful_api.Models.Customer", null)
                        .WithMany("Logins")
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("restful_api.Models.Order", b =>
                {
                    b.HasOne("restful_api.Models.Customer", null)
                        .WithMany("Orders")
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("restful_api.Models.OrderItem", b =>
                {
                    b.HasOne("restful_api.Models.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("restful_api.Models.Product", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("restful_api.Models.Product", b =>
                {
                    b.HasOne("restful_api.Models.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("cat_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
