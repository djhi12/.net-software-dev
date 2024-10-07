using Microsoft.EntityFrameworkCore; // Required for EF Core
using DJMovies.Data; // Required for accessing MovieAppContext
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the MovieAppContext with SQLite database
builder.Services.AddDbContext<MovieAppContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MovieAppContext")));

// Build the application
var app = builder.Build(); // Declare app only once

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services); // Call the seed data method
}

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

// Configure the default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
