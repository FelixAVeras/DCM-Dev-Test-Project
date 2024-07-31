﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClaimProcessing.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LOS")
                        .HasColumnType("int");

                    b.Property<string>("NPI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCharges")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("ClaimFlag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClaimFlags");
                });

            modelBuilder.Entity("ClaimItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<string>("DGXCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DgxAffect")
                        .HasColumnType("int");

                    b.Property<string>("DgxCCMCC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClaimId");

                    b.ToTable("ClaimItems");
                });

            modelBuilder.Entity("ClaimPricing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ClaimPricings");
                });

            modelBuilder.Entity("ClaimProcessing.Models.HospitalRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CHIRP_Rate")
                        .HasColumnType("int");

                    b.Property<int>("Contract")
                        .HasColumnType("int");

                    b.Property<decimal>("DeliverySDA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("HHSC_Publish_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("HospitalClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalPhysicalCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalPhysicalStreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HundredPercent")
                        .HasColumnType("int");

                    b.Property<int>("IpRate")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NPI")
                        .HasColumnType("int");

                    b.Property<string>("NpiMonth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PPR_PPC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SDA")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("HospitalRates");
                });

            modelBuilder.Entity("RuleHit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClaimId")
                        .HasColumnType("int");

                    b.Property<string>("RuleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RuleHits");
                });

            modelBuilder.Entity("ClaimItem", b =>
                {
                    b.HasOne("Claim", "Claim")
                        .WithMany("Items")
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Claim");
                });

            modelBuilder.Entity("Claim", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
