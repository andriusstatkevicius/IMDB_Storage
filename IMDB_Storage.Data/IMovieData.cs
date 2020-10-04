using IMDB_Storage.Core;
using System.Collections.Generic;

namespace IMDB_Storage.Data
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetMovieByName(string name);
        Movie GetById(int id);
        Movie Update(Movie updatedMovie);
        Movie Add(Movie newMovie);
        Movie Delete(int id);
        int GetMovieCount();
        int Commit();
    }
}
