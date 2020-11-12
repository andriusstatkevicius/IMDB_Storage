using IMDB_Storage.Core;
using IMDB_Storage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace IMDB_Storage.Pages.Movies
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IMovieData _movieData;
        private readonly ILogger<ListModel> _logger;

        public string Message { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        // Properties are only binded during a POST request
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IMovieData movieData, ILogger<ListModel> logger)
        {
            _config = config;
            _movieData = movieData;
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogError("Executing ListModel");
            //Message = _config["Message"];
            Movies = _movieData.GetMovieByName(SearchTerm);
        }
    }
}
