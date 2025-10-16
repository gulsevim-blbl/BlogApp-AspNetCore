using BlogApp_AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_AspNetCore.Data.Concreate.EfCore
{
    public static class SeedData //nesne tanımlamak zorunda kalmamak için static yaptık
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app) //neden IApplicationBuilder alıcaak? -çünkü ugulama içerisinde tanımlanana uygulamayı biz parametre olarak ilgili methoda vereceğiz app'e vereceğiz bunun tipi de IApplicationBuilder'ı karşılayan bir tip
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Entity.Tag { Text = "Web Programlama" },
                        new Entity.Tag { Text = "Backend" },
                        new Entity.Tag { Text = "Frontend" },
                        new Entity.Tag { Text = "php" }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "Gül Sevim Bülbül" },
                        new User { UserName = "Selma Dikici" },
                        new User { UserName = "Ahmet Yilmaz" }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.Net.Core",
                            Content = "Asp.net core dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Image = "1.jpg",
                            UserId = 1
                        },
                         new Post
                        {
                            Title = "React.js",
                            Content = "React.js dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-1),
                            Image = "2.jpg",
                            UserId = 1
                        },
                         new Post
                        {
                            Title = "Node.js",
                            Content = "Node.js dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                             Image = "3.jpg",
                            UserId = 2
                        }
                    
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}