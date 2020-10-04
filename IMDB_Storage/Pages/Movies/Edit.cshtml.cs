using IMDB_Storage.Core;
using IMDB_Storage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_Storage.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieData movieData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public List<Genre> GenresCheckBox { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; }

        public EditModel(IMovieData movieData, IHtmlHelper htmlHelper)
        {
            this.movieData = movieData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? movieId)
        {
            Genres = htmlHelper.GetEnumSelectList<Genre>();

            if (movieId.HasValue)
                Movie = movieData.GetById(movieId.Value);
            else
                Movie = new Movie();

            if (Movie is null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            // If all the information is valid as per validation checks
            if (!ModelState.IsValid)
            {
                Genres = htmlHelper.GetEnumSelectList<Genre>();
                return Page();
            }

            Movie.Genres = string.Join(",", GenresCheckBox);

            if (Movie.Id > 0)
                movieData.Update(Movie);
            else
                movieData.Add(Movie);

            movieData.Commit();

            // TempData works like a dictionary with the key/value pairs
            TempData["Message"] = "Movie saved!";
            return RedirectToPage("./Detail", new { movieId = Movie.Id });
        }
    }
}
