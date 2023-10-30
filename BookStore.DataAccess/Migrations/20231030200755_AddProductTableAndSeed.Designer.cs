﻿// <auto-generated />
using System;
using BookStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231030200755_AddProductTableAndSeed")]
    partial class AddProductTableAndSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DisplayOrder")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Tâm linh"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Văn học"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Lập trình"
                        });
                });

            modelBuilder.Entity("BookStore.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Liên Hoa Sinh, Nguyên Phong",
                            Description = "Tibetan Book of the Dead",
                            ISBN = "9781570627477",
                            ListPrice = 285000.0,
                            Price = 285000.0,
                            Price100 = 285000.0,
                            Price50 = 285000.0,
                            Title = "Tử Thư Tây Tạng (Tây Tạng Sinh Tử Kỳ Thư)"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Bảo Ninh",
                            Description = "The Sorrow of War",
                            ISBN = "1573225436",
                            ListPrice = 300000.0,
                            Price = 300000.0,
                            Price100 = 300000.0,
                            Price50 = 300000.0,
                            Title = "Nỗi buồn chiến tranh"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Nguyễn Thanh Việt",
                            Description = "The Sympathizer",
                            ISBN = "1543618022",
                            ListPrice = 360000.0,
                            Price = 360000.0,
                            Price100 = 360000.0,
                            Price50 = 360000.0,
                            Title = "Người Cảm Tình Viên"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
