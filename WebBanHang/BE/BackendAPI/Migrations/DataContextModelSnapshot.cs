﻿// <auto-generated />
using System;
using BackendAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BackendAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BackendAPI.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppRole");
                });

            modelBuilder.Entity("BackendAPI.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("BackendAPI.Entities.DonDatHang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("IdDonhang")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdDonhang");

                    b.HasIndex("IdProduct");

                    b.ToTable("DonDatHangs");
                });

            modelBuilder.Entity("BackendAPI.Entities.Donhang", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberPhone")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Total")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Donhangs");
                });

            modelBuilder.Entity("BackendAPI.Models.BlogRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Describe1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Describe2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Describe3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameBlog")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("BackendAPI.Models.CategoryRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BackendAPI.Models.HoadonbanRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdCustomer")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uuid");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TotalPrice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdProduct");

                    b.ToTable("Hoadonbans");
                });

            modelBuilder.Entity("BackendAPI.Models.HoadonnhapRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamePersonnel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Quantity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TotalPrice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Hoadonnhaps");
                });

            modelBuilder.Entity("BackendAPI.Models.KhachHangRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GioiTinh")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("BackendAPI.Models.PersonnelRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamePersonnel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Personnel");
                });

            modelBuilder.Entity("BackendAPI.Models.ProductRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameProduct")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameSupplier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OldPrice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter3")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter4")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter5")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter6")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Parameter7")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BackendAPI.Models.SupplierRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameSupplier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberPhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("BackendAPI.Entities.DonDatHang", b =>
                {
                    b.HasOne("BackendAPI.Entities.Donhang", "Donhang")
                        .WithMany()
                        .HasForeignKey("IdDonhang");

                    b.HasOne("BackendAPI.Models.ProductRequest", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donhang");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BackendAPI.Models.HoadonbanRequest", b =>
                {
                    b.HasOne("BackendAPI.Models.KhachHangRequest", "KhachHang")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendAPI.Models.ProductRequest", "Products")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
