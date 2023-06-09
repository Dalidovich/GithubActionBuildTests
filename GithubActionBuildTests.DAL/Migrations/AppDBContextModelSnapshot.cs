﻿// <auto-generated />
using System;
using GithubActionBuildTests.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GithubActionBuildTests.DAL.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GithubActionBuildTests.Domain.Models.SummaryCalc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_summary_id");

                    b.Property<short>("FirstNum")
                        .HasColumnType("smallint")
                        .HasColumnName("first_num");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("method_name");

                    b.Property<short>("SecondNum")
                        .HasColumnType("smallint")
                        .HasColumnName("second_num");

                    b.HasKey("Id");

                    b.ToTable("SummaryCalcs", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
