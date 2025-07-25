﻿// <auto-generated />
using System;
using Biogenom.NutritionReport.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biogenom.NutritionReport.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250713120121_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Benefit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.NutrientConsumption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("double precision");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeficient")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("RecommendedMax")
                        .HasColumnType("double precision");

                    b.Property<double>("RecommendedMin")
                        .HasColumnType("double precision");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("NutrientConsumptions");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.PersonalizedIntake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("NewValue")
                        .HasColumnType("double precision");

                    b.Property<string>("NutrientName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("PersonalizedIntakes");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Supplement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("Supplements");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Benefit", b =>
                {
                    b.HasOne("Biogenom.NutritionReport.Domain.Entities.Report", "Report")
                        .WithMany("Benefits")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.NutrientConsumption", b =>
                {
                    b.HasOne("Biogenom.NutritionReport.Domain.Entities.Report", "Report")
                        .WithMany("NutrientConsumptions")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.PersonalizedIntake", b =>
                {
                    b.HasOne("Biogenom.NutritionReport.Domain.Entities.Report", "Report")
                        .WithMany("PersonalizedIntakes")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Supplement", b =>
                {
                    b.HasOne("Biogenom.NutritionReport.Domain.Entities.Report", "Report")
                        .WithMany("Supplements")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");
                });

            modelBuilder.Entity("Biogenom.NutritionReport.Domain.Entities.Report", b =>
                {
                    b.Navigation("Benefits");

                    b.Navigation("NutrientConsumptions");

                    b.Navigation("PersonalizedIntakes");

                    b.Navigation("Supplements");
                });
#pragma warning restore 612, 618
        }
    }
}
