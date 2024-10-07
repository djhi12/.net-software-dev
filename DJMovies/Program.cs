using Microsoft.EntityFrameworkCore; // Required for EF Core
using DJMovies.Data; // Required for accessing MovieAppContext

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the MovieAppContext
builder.Services.AddDbContext<MovieAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieAppContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
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
