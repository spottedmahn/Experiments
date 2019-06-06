//https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite


using EF_Core_SomeId1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace ConsoleApp.SQLite
{
    public class BloggingContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
    = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseSqlite("Data Source=blogging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Id)
                .HasColumnName("BlogId");

            modelBuilder.Entity<Post>(post =>
            {
                post.Property(b => b.Id)
                .HasColumnName("PostId");

                post.HasOne(p => p.Blog)
                .WithMany()
                .HasForeignKey(p => p.BlogId);
            });

            //base.OnModelCreating(modelBuilder);
        }
    }
}