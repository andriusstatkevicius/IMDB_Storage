using IMDB_Storage.Core;
using IMDB_Storage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IMDB_Storage.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        public Movie _Movie;
        private readonly IMovieData _movieData;

        public DeleteModel(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IActionResult OnGet(int movieId)
        {
            _Movie = _movieData.GetById(movieId);
            if (_Movie is null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int movieId)
        {
            var movie = _movieData.Delete(movieId);

            if (movie is null)
                return RedirectToPage("./NotFound");

            _movieData.Commit();

            TempData["Message"] = $"{movie.Title} deleted";
            return RedirectToPage("./List");
        }
    }
}
