using MovieWeb.Models;

namespace MovieWeb.Repository
{
    public interface IUserMovieRepository :IRepository<UserMovie>
    {
        public IEnumerable<UserMovie> GetUserMoviesIncludedMovies();
    }
}
