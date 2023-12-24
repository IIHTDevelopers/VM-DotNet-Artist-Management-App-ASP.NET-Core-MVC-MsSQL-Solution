using Microsoft.EntityFrameworkCore;
using ArtistManagementApp.DAL;
using ArtistManagementApp.DAL.Interface;
using ArtistManagementApp.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArtistDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("ConnStr"));
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IArtistInterface, ArtistManagementService>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
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
