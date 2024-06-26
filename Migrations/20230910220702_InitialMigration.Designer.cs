﻿// <auto-generated />
using System;
using APPR6312_Part1_1_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APPR6312_Part1_1_.Migrations
{
    [DbContext(typeof(DAFAppDbContext))]
    [Migration("20230910220702_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APPR6312_PART1.Models.Domain.Disaster", b =>
                {
                    b.Property<Guid>("DisasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisasterDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisasterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DisasterId");

                    b.ToTable("Disasters");
                });

            modelBuilder.Entity("APPR6312_PART1.Models.Domain.MonetaryDonation", b =>
                {
                    b.Property<Guid>("MoneyDonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.HasKey("MoneyDonationId");

                    b.ToTable("MonetaryDonations");
                });

            modelBuilder.Entity("APPR6312_PART1.Models.Domain.goodsDonation", b =>
                {
                    b.Property<Guid>("goodDonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<string>("goodsCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("goodDonationId");

                    b.ToTable("goodsDonations");
                });
#pragma warning restore 612, 618
        }
    }
}
