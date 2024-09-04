using MovieWeb.Models;

namespace MovieWeb.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public IEnumerable<Movie> GetMoviesIncludedUserMovie();
    }
}
