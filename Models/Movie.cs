using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Director { get; set; } = string.Empty;

        [Range(1888, 2100)]
        public int ReleaseYear { get; set; }

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;
    }
}