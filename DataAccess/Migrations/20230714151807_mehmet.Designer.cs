﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(FlimsApiDbContext))]
    [Migration("20230714151807_mehmet")]
    partial class mehmet
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginPassworld")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Entity.Result", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Rootobjectpage")
                        .HasColumnType("int");

                    b.Property<bool>("adult")
                        .HasColumnType("bit");

                    b.Property<string>("backdrop_path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_air_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre_ids")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("media_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("popularity")
                        .HasColumnType("real");

                    b.Property<string>("poster_path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("release_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("video")
                        .HasColumnType("bit");

                    b.Property<float>("vote_average")
                        .HasColumnType("real");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Rootobjectpage");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Entity.Rootobject", b =>
                {
                    b.Property<int>("page")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("page"));

                    b.Property<int>("total_pages")
                        .HasColumnType("int");

                    b.Property<int>("total_results")
                        .HasColumnType("int");

                    b.HasKey("page");

                    b.ToTable("Rootobjects");
                });

            modelBuilder.Entity("Entity.Result", b =>
                {
                    b.HasOne("Entity.Rootobject", null)
                        .WithMany("results")
                        .HasForeignKey("Rootobjectpage");
                });

            modelBuilder.Entity("Entity.Rootobject", b =>
                {
                    b.Navigation("results");
                });
#pragma warning restore 612, 618
        }
    }
}
