using ConsoleApp.SQLite;
using EF_Core_SomeId1.Models;
using System;
using System.Linq;

namespace EF_Core_SomeId1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteBlog();

            WriteBlogPost();

            ReadBlogs();

            ReadBlogPosts();
        }

        private static void WriteBlog()
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine($"{count.ToString()} blog records saved to database");
            }
        }

        private static void WriteBlogPost()
        {
            using (var db = new BloggingContext())
            {
                db.Posts.Add(new Post
                {
                    Blog = db.Blogs.First(),
                    Title = "Hello World",
                    Content = "Some content"
                });
                db.SaveChanges();
            }
        }

        private static void ReadBlogs()
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }

        private static void ReadBlogPosts()
        {
            using (var db = new BloggingContext())
            {
                var query = db.Blogs
                                .Select(b => new
                                {
                                    b.Id,
                                    FirstPost = b.Posts.OrderBy(p => p.Id).FirstOrDefault() == null ? null : b.Posts.OrderBy(p => p.Id).FirstOrDefault().Title
                                });

                var blah = query.ToList();

                Console.WriteLine();
                Console.WriteLine("All blog post in database:");

                foreach (var rec in blah)
                {
                    Console.WriteLine($"{rec.Id} - {rec.FirstPost}");
                }
            }
        }
    }
}