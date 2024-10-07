using Microsoft.EntityFrameworkCore;
using DJMovies.Models;

namespace DJMovies.Data
{
    public class MovieAppContext : DbContext
    {
        public MovieAppContext(DbContextOptions<MovieAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
