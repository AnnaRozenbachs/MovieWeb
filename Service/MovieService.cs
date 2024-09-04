using MovieWeb.Models;
using MovieWeb.Repository;
using MovieWeb.Extensions;

namespace MovieWeb.Service
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.Add(movie);
        }

        public Movie GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);    
            return movie;
        }

        public IEnumerable<Movie> GetMovieList(string searchValue, int categoryId)
        {
            var movies = _movieRepository.GetMoviesIncludedUserMovie();

            if (!string.IsNullOrEmpty(searchValue))
            {
                movies = movies.Where(m => m.Title.ContainsString(searchValue));
            }
            if (categoryId > 0)
            {
                movies = movies.Where(m => m.CategoryId == categoryId);
            }

            return movies;
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(Movie movie) 
        {
            _movieRepository.Delete(movie);
        }
    }
}
