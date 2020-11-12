using IMDB_Storage.Data;
using Microsoft.AspNetCore.Mvc;

namespace IMDB_Storage.ViewComponents
{
    public class MovieCountViewComponent : ViewComponent
    {
        private readonly IMovieData _movieData;

        public MovieCountViewComponent(IMovieData movieData)
        {
            _movieData = movieData;
        }

        public IViewComponentResult Invoke()
        {
            var count = _movieData.GetMovieCount();
            return View(count);
        }
    }
}
