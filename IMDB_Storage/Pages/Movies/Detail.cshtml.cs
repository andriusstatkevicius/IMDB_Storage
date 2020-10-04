using IMDB_Storage.Core;
using IMDB_Storage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDB_Storage.Pages.Movies
{
    public class DetailModel : PageModel
    {
        private readonly IMovieData _movieData;

        // TempData received from Edit page
        [TempData] public string Message { get; set; }

        public Movie Movie { get; set; }

        public DetailModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        // This is strictly an input model, hence this is defined as a parameter
        // IActionResult allows to control what's return on GET request
        public IActionResult OnGet(int movieId)
        {
            Movie = _movieData.GetById(movieId);

            if (Movie is null)
                return RedirectToPage("./NotFound");

            return Page();
        }
    }
}
