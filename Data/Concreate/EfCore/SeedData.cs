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
                        new Entity.Tag { Text = "Web Programlama" , Url = "web-programlama", Color = TagColors.warning },
                        new Entity.Tag { Text = "Backend", Url = "backend" , Color = TagColors.danger },
                        new Entity.Tag { Text = "Frontend", Url= "frontend" , Color = TagColors.success},
                        new Entity.Tag { Text = "php", Url= "php" , Color = TagColors.primary }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "GülSevimBülbül", Name = "Gül Sevim Bülbül", Email = "info@gulsevimblbl.com", Password = "123456", Image = "p1.jpg" },
                        new User { UserName = "AhmetYilmaz", Name = "Ahmet Yılmaz", Email = "info@ahmetyilmaz.com", Password = "123456", Image = "p4.jpg" },

                        new User { UserName = "handeSonmez",Name="Hande Sonmez",Email="info@handesonmez.com",Password="123456" , Image = "p3.jpg" }
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
                            Url = "asp-net-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Text = "Harika bir ders olmuş, teşekkürler!",
                                    PublishedOn = DateTime.Now.AddDays(-10),
                                    UserId= 1 
                                },
                                new Comment
                                {
                                    Text = "Çok faydalı bilgiler edindim.",
                                    PublishedOn = DateTime.Now.AddDays(-2),
                                    UserId= 3
                                }
                            }
                        },
                         new Post
                         {
                             Title = "React.js",
                             Content = "React.js dersleri",
                             Url = "react-js",
                             IsActive = true,
                             PublishedOn = DateTime.Now.AddDays(-1),
                             Tags = context.Tags.Take(2).ToList(),
                             Image = "2.jpg",
                             UserId = 1
                         },
                         new Post
                         {
                             Title = "Node.js",
                             Content = "Node.js dersleri",
                             Url = "node-js",
                             IsActive = true,
                             PublishedOn = DateTime.Now.AddDays(-5),
                             Tags = context.Tags.Take(2).ToList(),
                             Image = "3.jpg",
                             UserId = 2
                         },
                        new Post
                        {
                            Title = "PHP",
                            Content = "PHP dersleri",
                            Url = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(1).ToList(),
                            Image = "1.jpg",
                            UserId = 3
                        },
                        new Post
                        {
                            Title = "Kubernetes",
                            Content = "Kubernetes dersleri",
                            Url = "Kubernetes",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "2.jpg",
                            UserId = 3
                        },
                        new Post
                        {
                            Title = "Vue.js",
                            Content = "Vue.js dersleri",
                            Url = "vue-js",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-8),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                         new Post
                         {
                             Title = "Docker",
                             Content = "Docker dersleri",
                             Url = "docker",
                             IsActive = true,
                             PublishedOn = DateTime.Now.AddDays(-8),
                             Tags = context.Tags.Take(2).ToList(),
                             Image = "3.jpg",
                             UserId = 2
                         },
                        new Post
                        {
                            Title = "Angular",
                            Content = "Angular dersleri",
                            Url = "angular",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-3),
                            Tags = context.Tags.Take(1).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}