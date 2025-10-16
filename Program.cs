using BlogApp_AspNetCore.Data.Concreate.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //controllerin viewlerle iliskisini kuruyoruz.


builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("mysql_connection");
    //options.UseSqlite(connectionString);
    var version = new MySqlServerVersion(new Version(8,0,41)); //mysql in versionunu girdim
    options.UseMySql(connectionString, version);
});


var app = builder.Build();

SeedData.TestVerileriniDoldur(app);


app.MapDefaultControllerRoute();


app.Run();
