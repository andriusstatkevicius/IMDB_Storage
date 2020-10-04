using IMDB_Storage.Core;
using Microsoft.EntityFrameworkCore;

namespace IMDB_Storage.Data
{
    public class IMDB_StorageDBContext : DbContext
    {
        public IMDB_StorageDBContext(DbContextOptions<IMDB_StorageDBContext> options) 
            : base(options) { }

        // This is the type that I want to tell EF that I want to query for Movie in the DB
        // But I also want to be able to insert, update and delete
        public DbSet<Movie> Movies { get; set; }
    }
}
