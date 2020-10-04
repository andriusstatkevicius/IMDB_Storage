using System.ComponentModel.DataAnnotations;

namespace IMDB_Storage.Core
{
    public class Movie
    {
        [Required, StringLength(80)] public string Title { get; set; }

        [Required, Range(0, 10.0)]
        public decimal Rate { get; set; }

        public string Genres { get; set; }

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
