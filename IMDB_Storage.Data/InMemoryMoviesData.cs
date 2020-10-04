using IMDB_Storage.Core;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_Storage.Data
{
    public class InMemoryMoviesData : IMovieData
    {
        private readonly List<Movie> movies;

        public InMemoryMoviesData()
        {
            movies = new List<Movie>
            {
                new Movie { Id =0, Title = "Equilibrium", Rate = 7.4M, Genres = $"{Genre.Action},{Genre.SciFi},{Genre.Drama}" },
                new Movie { Id = 1, Title = "Vanishing Time: A boy who returned", Rate=7.3M, Genres = $"{Genre.Fantasy}" }
            };
        }

        public Movie Add(Movie newMovie)
        {
            movies.Add(newMovie);
            newMovie.Id = movies.Max(m => m.Id) + 1;
            return newMovie;
        }

        public Movie Delete(int id)
        {
            var movie = movies.SingleOrDefault(r => r.Id == id);
            if (movie != null)
                movies.Remove(movie);

            return movie;
        }

        public IEnumerable<Movie> GetMovieByName(string name) => movies.Where(r => string.IsNullOrEmpty(name) || r.Title.StartsWith(name))
                                                                       .OrderBy(r => r.Title);

        public int GetMovieCount() => movies.Count();

        public Movie Update(Movie updatedMovie)
        {
            var movie = movies.SingleOrDefault(r => r.Id == updatedMovie.Id);

            // TODO: Use reflections
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Genres = updatedMovie.Genres;
                movie.Rate = updatedMovie.Rate;
                movie.Description = updatedMovie.Description;
            }

            return movie;
        }

        public int Commit() => 0;

        public Movie GetById(int id) => movies.SingleOrDefault(m => m.Id == id);
    }
}
