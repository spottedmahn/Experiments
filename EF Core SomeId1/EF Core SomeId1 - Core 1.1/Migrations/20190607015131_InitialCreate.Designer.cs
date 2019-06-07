using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ConsoleApp.SQLite;

namespace EF_Core_SomeId1.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20190607015131_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6");

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
        }
    }
}
