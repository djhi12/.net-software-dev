using System;
using System.ComponentModel.DataAnnotations;

namespace DJMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 10)]
        public decimal Rating { get; set; }
    }
}
