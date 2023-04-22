﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsersAndCompaniesDataAccess;

#nullable disable

namespace UsersAndCompaniesDataAccess.Migrations
{
    [DbContext(typeof(UsersAndCompaniesContext))]
    [Migration("20230422120455_IndexesAndRequiredFields")]
    partial class IndexesAndRequiredFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UsersAndCompaniesDataAccess.Entities.CompanyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_Companies");

                    b.ToTable("Companies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ba06365-8ead-47e2-b9f0-ba234083a762"),
                            Address = "Default Address",
                            CompanyName = "Default Company"
                        });
                });

            modelBuilder.Entity("UsersAndCompaniesDataAccess.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PrimaryKey_Users");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Surname")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("03ce25d6-c10b-45cf-abb3-6d280f4e8e52"),
                            CompanyId = new Guid("0ba06365-8ead-47e2-b9f0-ba234083a762"),
                            Name = "Default User",
                            Surname = "Default User"
                        });
                });

            modelBuilder.Entity("UsersAndCompaniesDataAccess.Entities.UserEntity", b =>
                {
                    b.HasOne("UsersAndCompaniesDataAccess.Entities.CompanyEntity", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("UsersAndCompaniesDataAccess.Entities.CompanyEntity", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}