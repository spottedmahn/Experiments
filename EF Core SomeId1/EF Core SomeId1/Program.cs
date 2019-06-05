using ConsoleApp.SQLite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace EF_Core_SomeId1
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                db.Posts.Add(new Post
                {
                    Blog = db.Blogs.First(),
                    Title = "Hello World",
                    Content = "Some content"
                });
                db.SaveChanges();
            }

            using (var db = new BloggingContext())
            {
                var query = db.Blogs
                                .Select(b => new
                                {
                                    b.Id,
                                    FirstPost = b.Posts.OrderBy(p => p.Id).FirstOrDefault() == null ? null : b.Posts.OrderBy(p => p.Id).FirstOrDefault().Title
                                });

                var blah = query.ToList();
                foreach (var rec in blah)
                {
                    Console.WriteLine($"{rec.Id} - {rec.FirstPost}");
                }
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddDebug());
        }
    }
}
