﻿// <auto-generated />
using System;
using ASP_CORE_BASIC_NET_6_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPCOREBASICNET6API.Migrations
{
    [DbContext(typeof(DBContextBase))]
    [Migration("20221215103013_Initial_v1")]
    partial class Initialv1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssetId"));

                    b.Property<string>("AssetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("AssetQuantity")
                        .HasColumnType("float");

                    b.Property<int>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("AssetId");

                    b.HasIndex("WalletId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserDetails", b =>
                {
                    b.Property<int>("UserDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserDetailsId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BirthDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("UserDetailsId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserRole", b =>
                {
                    b.Property<int>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleId"));

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalletId"));

                    b.Property<int>("UserDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("WalletName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WalletId");

                    b.HasIndex("UserDetailsId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.Asset", b =>
                {
                    b.HasOne("ASP_CORE_BASIC_NET_6_API.Repository.Models.Wallet", "Wallet")
                        .WithMany("Assets")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserDetails", b =>
                {
                    b.HasOne("ASP_CORE_BASIC_NET_6_API.Repository.Models.User", "User")
                        .WithOne("UserDetails")
                        .HasForeignKey("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserDetails", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserRole", "UserRole")
                        .WithMany()
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.Wallet", b =>
                {
                    b.HasOne("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserDetails", "UserDetails")
                        .WithMany("Wallets")
                        .HasForeignKey("UserDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.User", b =>
                {
                    b.Navigation("UserDetails");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.UserDetails", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("ASP_CORE_BASIC_NET_6_API.Repository.Models.Wallet", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
