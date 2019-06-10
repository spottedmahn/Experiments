﻿// <auto-generated />
using System;
using ConsoleApp.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF_Core_SomeId1.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("EF_Core_SomeId1.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BlogId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EF_Core_SomeId1.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PostId");

                    b.Property<int>("BlogId");

                    b.Property<int?>("BlogId1");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("BlogId1");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EF_Core_SomeId1.Models.Post", b =>
                {
                    b.HasOne("EF_Core_SomeId1.Models.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EF_Core_SomeId1.Models.Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId1");
                });
#pragma warning restore 612, 618
        }
    }
}