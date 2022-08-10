﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TailoringApp.Context;

#nullable disable

namespace TailoringApp.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TailoringApp.Entity.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Cloth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ColourId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColourId");

                    b.ToTable("Cloths", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Colour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Colours", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Design", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext");

                    b.Property<string>("Picture2")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.ToTable("Designs", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Area")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Locations", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClothId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Picture")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClothId");

                    b.ToTable("Measurements", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ColourId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerDesign")
                        .HasColumnType("longtext");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DesignId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ColourId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DesignId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.OrderMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AgbadaLenght")
                        .HasColumnType("longtext");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("KneekerLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("KneekerTight")
                        .HasColumnType("longtext");

                    b.Property<string>("KneekerWaist")
                        .HasColumnType("longtext");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NativeCap")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeShoulder")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeSleeve")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeTrouserKnee")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeTrouserLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeTrouserTight")
                        .HasColumnType("longtext");

                    b.Property<string>("NativeWaist")
                        .HasColumnType("longtext");

                    b.Property<string>("ShirtLeght")
                        .HasColumnType("longtext");

                    b.Property<string>("ShirtShoulder")
                        .HasColumnType("longtext");

                    b.Property<string>("ShirtSleeve")
                        .HasColumnType("longtext");

                    b.Property<string>("ShirtWaist")
                        .HasColumnType("longtext");

                    b.Property<string>("SuitChest")
                        .HasColumnType("longtext");

                    b.Property<string>("SuitLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("SuitShoulder")
                        .HasColumnType("longtext");

                    b.Property<string>("SuitSleeve")
                        .HasColumnType("longtext");

                    b.Property<string>("SuitWaist")
                        .HasColumnType("longtext");

                    b.Property<string>("TrouserKnee")
                        .HasColumnType("longtext");

                    b.Property<string>("TrouserLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("TrouserTight")
                        .HasColumnType("longtext");

                    b.Property<string>("TrouserWaist")
                        .HasColumnType("longtext");

                    b.Property<string>("WaistCoatLenght")
                        .HasColumnType("longtext");

                    b.Property<string>("WaistCoatWaist")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("OrderMeasurements", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderReference")
                        .HasColumnType("longtext");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CustomerID");

                    b.ToTable("payments", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("IsDeleteOn")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("TailoringApp.Entity.Admin", b =>
                {
                    b.HasOne("TailoringApp.Identity.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("TailoringApp.Entity.Admin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TailoringApp.Entity.Cart", b =>
                {
                    b.HasOne("TailoringApp.Entity.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TailoringApp.Entity.Cloth", b =>
                {
                    b.HasOne("TailoringApp.Entity.Category", "Category")
                        .WithMany("Cloths")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Entity.Colour", null)
                        .WithMany("Cloths")
                        .HasForeignKey("ColourId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TailoringApp.Entity.Customer", b =>
                {
                    b.HasOne("TailoringApp.Entity.Location", "Location")
                        .WithOne("Customer")
                        .HasForeignKey("TailoringApp.Entity.Customer", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Identity.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("TailoringApp.Entity.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TailoringApp.Entity.Design", b =>
                {
                    b.HasOne("TailoringApp.Entity.Cloth", "Cloth")
                        .WithMany("Designs")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");
                });

            modelBuilder.Entity("TailoringApp.Entity.Measurement", b =>
                {
                    b.HasOne("TailoringApp.Entity.Cloth", "Cloth")
                        .WithMany("Measurements")
                        .HasForeignKey("ClothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cloth");
                });

            modelBuilder.Entity("TailoringApp.Entity.Order", b =>
                {
                    b.HasOne("TailoringApp.Entity.Cart", "Cart")
                        .WithMany("Orders")
                        .HasForeignKey("CartId");

                    b.HasOne("TailoringApp.Entity.Colour", "Colour")
                        .WithMany()
                        .HasForeignKey("ColourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Entity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Entity.Design", "Design")
                        .WithMany("Orders")
                        .HasForeignKey("DesignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Colour");

                    b.Navigation("Customer");

                    b.Navigation("Design");
                });

            modelBuilder.Entity("TailoringApp.Entity.OrderMeasurement", b =>
                {
                    b.HasOne("TailoringApp.Entity.Customer", "Customer")
                        .WithOne("OrderMeasurement")
                        .HasForeignKey("TailoringApp.Entity.OrderMeasurement", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TailoringApp.Entity.Payment", b =>
                {
                    b.HasOne("TailoringApp.Entity.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TailoringApp.Identity.UserRole", b =>
                {
                    b.HasOne("TailoringApp.Identity.Role", "Role")
                        .WithMany("UserRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TailoringApp.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TailoringApp.Entity.Cart", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TailoringApp.Entity.Category", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("TailoringApp.Entity.Cloth", b =>
                {
                    b.Navigation("Designs");

                    b.Navigation("Measurements");
                });

            modelBuilder.Entity("TailoringApp.Entity.Colour", b =>
                {
                    b.Navigation("Cloths");
                });

            modelBuilder.Entity("TailoringApp.Entity.Customer", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrderMeasurement");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TailoringApp.Entity.Design", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TailoringApp.Entity.Location", b =>
                {
                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TailoringApp.Identity.Role", b =>
                {
                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TailoringApp.Identity.User", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Customer");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}