﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaneForce.Services.ProductAPI.Data;

#nullable disable

namespace SaneForce.Services.ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241108234733_SeedProductTable")]
    partial class SeedProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaneForce.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Code"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Code");

                    b.ToTable("ProductMaster");

                    b.HasData(
                        new
                        {
                            Code = 111,
                            Name = "mango",
                            Rate = 12m
                        },
                        new
                        {
                            Code = 222,
                            Name = "apple",
                            Rate = 10m
                        },
                        new
                        {
                            Code = 333,
                            Name = "banana",
                            Rate = 13m
                        },
                        new
                        {
                            Code = 444,
                            Name = "pine apple",
                            Rate = 14m
                        },
                        new
                        {
                            Code = 555,
                            Name = "grapes",
                            Rate = 16m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}