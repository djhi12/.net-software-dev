using Microsoft.EntityFrameworkCore;
using DJMovies.Models; // Ensure this matches your Movie model namespace
using System;

namespace DJMovies.Data
{
    // Database context for your Movie model
    public class MovieAppContext : DbContext
    {
        public MovieAppContext(DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } // This defines the Movies table in your database
    }

    // SeedData class for initializing the database with some records
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieAppContext>>()))
            {
                if (context.Movies.Any()) return; // If there are already movies, return

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Inception",
                        Genre = "Sci-Fi",
                        ReleaseDate = DateTime.Parse("2010-07-16"),
                        Rating = 9.0M
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Genre = "Action",
                        ReleaseDate = DateTime.Parse("1999-03-31"),
                        Rating = 8.7M
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        Genre = "Sci-Fi",
                        ReleaseDate = DateTime.Parse("2014-11-07"),
                        Rating = 8.6M
                    }
                );
                context.SaveChanges(); // Save changes to the database
            }
        }
    }
}
