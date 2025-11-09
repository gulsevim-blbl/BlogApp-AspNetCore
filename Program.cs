using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //controllerin viewlerle iliskisini kuruyoruz.


builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("mysql_connection");
    //options.UseSqlite(connectionString);
    var version = new MySqlServerVersion(new Version(8, 0, 41)); //mysql in versionunu girdim
    options.UseMySql(connectionString, version);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();//yani  sanal versiyonunu verdiğim zaman sanala karşılık gerçek versiyonu bana gönder diyorum. AddScoped diyorum çünkü her istek için yeni bir instance oluşturulsun istiyorum.
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
//sema aracılığıyla yetkilendirme işlemlerini yapabilirim.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath ="/Users/Login"; //giriş yapılmamışsa yönlendirilecek sayfa. (/Account/Login e yönlendiriyor default olarak biz ise bunu değiştirdik.)
});


var app = builder.Build();

app.UseStaticFiles();
//sıralama önemlidir .UseAuthentication ve UseAuthorization middlewarelarını eklediğimizde bunlardan önce Routing'in yapılandırılması önemli.
app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization(); //yetkilendirme middleware ini ekliyorum

SeedData.TestVerileriniDoldur(app);


//Localhost://posts/react-dersleri
//localhost://posts/php dersleri

app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller = "Posts", action = "Details" }
);
//localhost://posts/tag/php dersleri

app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller = "Posts", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
