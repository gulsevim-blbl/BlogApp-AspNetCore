using BlogApp_AspNetCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp_AspNetCore.Data.Concreate.EfCore
{
    public class BlogContext : DbContext
    {
        //*Bu context'imiz db contextten türetilecek bu yüzden    projeye kütüphane ekliyoruz.        
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        //*burada base ile dbcontextin constructorını çağırıyoruz.
        {

        }
        //dbSetlerimiz bizim için entitylerimizin vermiş olduğu classları db de tablo olarak oluşturacak.
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        
    }
}