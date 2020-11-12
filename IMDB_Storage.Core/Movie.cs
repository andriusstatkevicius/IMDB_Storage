using System.ComponentModel.DataAnnotations;

namespace IMDB_Storage.Core
{
    public class Movie
    {
        [Required, StringLength(80)] public string Title { get; set; }

        [Required(ErrorMessage = "Please specify the rate (between 0-10, with one decimal place)"), Range(0, 10.0)]
        [RegularExpression(@"^\d+\.*\d{0,1}$", ErrorMessage = "Rate must be between 0-10 with one decimal place")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public decimal Rate { get; set; }

        public string Genres { get; set; }

        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
