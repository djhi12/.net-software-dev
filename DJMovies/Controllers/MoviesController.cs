using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DJMovies.Data;  // Make sure the namespace is correct
using DJMovies.Models;

namespace DJMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieAppContext _context;

        public MoviesController(MovieAppContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string searchString, int? year)
        {
            var movies = from m in _context.Movies
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (year.HasValue)
            {
                movies = movies.Where(m => m.ReleaseDate.Year >= year.Value);
            }

            return View(await movies.ToListAsync());
        }

        // Add other action methods (Create, Edit, Delete, etc.) here
    }
}
