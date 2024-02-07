using Microsoft.EntityFrameworkCore;
using OtarioLearning.ServiceCollection;
using OtarioStudy.DataBaseContext;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OtarioDbContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ConnectionStr")));
ServiceCollectionExtention.Services(builder.Services);
Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("", rollingInterval: RollingInterval.Day).CreateLogger();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
