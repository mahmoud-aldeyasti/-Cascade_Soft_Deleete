using Save_Changes_interceptors.Data.Context;
using Save_Changes_interceptors.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_Changes_interceptors.Data.Helper
{
    public static class DataBaseHelper
    {

        public static void CreateOrRecreateDataBase()
        {
            using var context = new SaveChangesInterceptorsDbContext();

            context.Database.EnsureDeleted(); // Delete the database if it exists

            context.Database.EnsureCreated(); // Create the database
        }


        public static void PopulateDatabase()
        {
            using (var context = new SaveChangesInterceptorsDbContext())
            {
                context.blogs.AddRange(

                    new Blog()
                    {
                        Name = "Cooking Blog",
                        Description = "This is a cooking BLog" 
                    },

                    new Blog()
                    {
                        Name = "Sports Blog",
                        Description = "This is sports blog"
                    },
                    new Blog()
                    {
                        Name = "Fashon Blog",
                        Description  = "This is a fashion blog"
                    }
                );

                context.posts.AddRange(
                    
                    new Post()
                    {
                        Title = "Cooking Post 1",
                        author = "Author1",
                        BlogId = 1
                    },
                    new Post()
                    {
                        Title = "Cooking Post 2",
                        author = "Author2",
                        BlogId = 1
                    },
                    new Post()
                    {
                        Title = "Cooking Post 3",
                        author = "Author3",
                        BlogId = 1
                    },
                    new Post()
                    {
                        Title = "Cooking Post 4",
                        author = "Author4",
                        BlogId = 1
                    },
                    new Post()
                    {
                        Title = "Sports Post 1",
                        author = "Author1",
                        BlogId = 2
                    },
                    new Post()
                    {
                        Title = "Sports Post 2",
                        author = "Author2",
                        BlogId = 2
                    },
                    new Post()
                    {
                        Title = "Sports Post 3",
                        author = "Author3",
                        BlogId = 2
                    },
                    new Post()
                    {
                        Title = "Sports Post 4",
                        author = "Author4",
                        BlogId = 2
                    }

                );

                context.SaveChanges();
            }
        }

        public static void ShowBlogs()
        {
            Console.WriteLine("-----------------------Blogs----------------------");

            using (var context = new SaveChangesInterceptorsDbContext() )
            {
                foreach(var blog in context.blogs)
                {
                    Console.WriteLine($"Blog ID: {blog.Id}, Name: {blog.Name}, Description: {blog.Description}" +
                        $",Isdeleted {blog.IsDeleted} ");
                }
            }
        }


        public static void ShowPosts()
        {
            Console.WriteLine("-----------------------Posts----------------------");

            using (var context = new SaveChangesInterceptorsDbContext())
            {
                // this pattern is called Domain driven pattern which means when you access
                // the blog you can access the posts directly and only from the blog
                //which helps on applying on delete cascade behavior on the process 

                foreach (var post in context.blogs.SelectMany( b => b.Posts ) )
                {
                    Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}, Author: {post.author}" +
                        $",Isdeleted {post.IsDeleted} ");
                }
            }
        }


        public static void DeleteFirstBlog()
        {
            using (var context = new SaveChangesInterceptorsDbContext())
            {
                var blog = context.blogs.FirstOrDefault();

                if (blog != null)
                {
                    context.blogs.Remove(blog);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No blogs found to delete.");
                }
            }
        }
    }
}

