using Microsoft.EntityFrameworkCore;
using MovieWeb.Data;
using MovieWeb.Models;

namespace MovieWeb.Repository
{
    public class UserMovieRepository: Repository<UserMovie>,IUserMovieRepository
    {
        private ApplicationDbContext _context;
        public UserMovieRepository(ApplicationDbContext context, ILogger<UserMovie> logger) : 
            base(context,logger)
        {
            _context = context;
        }

        public IEnumerable<UserMovie> GetUserMoviesIncludedMovies()
        {
            return _context.UserMovie.Include(u => u.Movie);
        }
    }
}
