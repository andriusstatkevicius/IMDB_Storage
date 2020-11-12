using IMDB_Storage.Core;
using IMDB_Storage.Data;
using IMDB_Storage.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB_Storage.Pages.Movies
{
    public class IMDBPopulateModel : PageModel
    {
        private readonly IMovieData _movieData;

        [BindProperty]
        [Required,
         RegularExpression(@"((https://w{3}\.imdb\.com/title/t{2}[0-9]*/\?ref_=[a-zA-Z0-9_]*))", ErrorMessage = "Not valid IMDB link")]
        public string _imdbLink { get; set; }

        public IMDBPopulateModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Movie movie = await PopulateMovieAsync();

            if (movie is null)
                return Page();

            if (movie.Id > 0)
                _movieData.Update(movie);
            else
                _movieData.Add(movie);

            _movieData.Commit();

            // TempData works like a dictionary with the key/value pairs
            TempData["Message"] = "Movie saved!";
            return RedirectToPage("./Detail", new { movieId = movie.Id }); // TODO: check if needed
        }

        private async Task<Movie> PopulateMovieAsync()
        {
            // TODO: Extract description and check why page is loaded in Lithuanian
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_imdbLink);
            var responseString = await response.Content.ReadAsStringAsync();

            var title = Regexes.Title.Matches(responseString ?? string.Empty).TryGetString(0, 1).Replace("&nbsp;", "");
            var rate = Regexes.Rate.Matches(responseString ?? string.Empty).TryGetString(0, 1);

            if (string.IsNullOrWhiteSpace(title) || !decimal.TryParse(rate, out decimal parsedRate))
                return null;

            var genresArea = Regexes.GenresArea.Matches(responseString).TryGetString(0, 0);
            var genres = Regexes.Genres.Matches(genresArea ?? string.Empty).TryGetArray(0, 1);

            return new Movie()
            {
                Genres = string.Join(",", genres ?? new string[] { }),
                Title = title,
                Rate = parsedRate,
            };
        }
    }
}
