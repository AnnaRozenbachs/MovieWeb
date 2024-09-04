using MovieWeb.Models;
using System.Runtime.CompilerServices;

namespace MovieWeb.Service
{
    public interface IMovieService
    {
        public Movie GetMovieById(int id);

        public void AddMovie(Movie movie);

        public void UpdateMovie(Movie movie);

        public IEnumerable<Movie> GetMovieList(string searchValue, int categoryId);

        public void DeleteMovie(Movie movie);

    }
}
