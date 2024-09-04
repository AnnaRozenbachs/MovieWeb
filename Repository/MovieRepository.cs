using Microsoft.EntityFrameworkCore;
using MovieWeb.Data;
using MovieWeb.Models;
using SQLitePCL;

namespace MovieWeb.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext 
            context, ILogger<Movie> logger) :base (context, logger)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetMoviesIncludedUserMovie()
        {
            return _context.Movie.Include(m => m.UserMovies);
        }

    }
}
