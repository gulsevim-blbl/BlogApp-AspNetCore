using BlogApp_AspNetCore.Data.Abstract;
using BlogApp_AspNetCore.Data.Concreate;
using BlogApp_AspNetCore.Data.Concreate.EfCore;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddScoped<IPostRepostory, EfPostRepostory>();//yani  sanal versiyonunu verdiğim zaman sanala karşılık gerçek versiyonu bana gönder diyorum. AddScoped diyorum çünkü her istek için yeni bir instance oluşturulsun istiyorum.
builder.Services.AddScoped<ITagRepostory, EfTagRepostory>();

var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);


app.MapDefaultControllerRoute();


app.Run();
