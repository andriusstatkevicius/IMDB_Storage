using IMDB_Storage.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IMDB_Storage.Data
{
    public class SQLMovieData : IMovieData
    {
        private readonly IMDB_StorageDBContext _db;

        public SQLMovieData(IMDB_StorageDBContext db)
        {
            _db = db;
        }

        public Movie Add(Movie newMovie)
        {
            _db.Add(newMovie);
            return newMovie;
        }

        public int Commit() => _db.SaveChanges();

        public Movie Delete(int id)
        {
            var movie = GetById(id);

            if (!(movie is null))
                _db.Movies.Remove(movie);

            return movie;
        }

        public Movie GetById(int id) => _db.Movies.Find(id);

        public IEnumerable<Movie> GetMovieByName(string name)
        {
            var query = _db.Movies.Where(movie => movie.Title.Contains(name) || string.IsNullOrEmpty(name))
                                  .OrderBy(movie => movie.Title).ToList();

            return query;
        }

        public int GetMovieCount() => _db.Movies.Count();

        public Movie Update(Movie updatedMovie)
        {
            var entity = _db.Attach(updatedMovie);
            entity.State = EntityState.Modified;
            return updatedMovie;
        }
    }
}
