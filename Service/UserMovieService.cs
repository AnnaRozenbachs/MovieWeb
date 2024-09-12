using MovieWeb.Models;
using MovieWeb.Repository;

namespace MovieWeb.Service
{
    public class UserMovieService : IUserMovieService
    {
        private IUserMovieRepository _userMovieRepository;
        public UserMovieService(IUserMovieRepository userMovieRepository)
        {
            _userMovieRepository = userMovieRepository;
        }
        public void AddMovieToFavourites(int movieId, string userId)
        {
            var userMovie = GetExistingMovie(movieId, userId);
            if (userMovie is not null)
            {
                _userMovieRepository.Delete(userMovie);
            }
            else
            {
                userMovie = new UserMovie
                {
                    UserId = userId,
                    MovieId = movieId
                };
                _userMovieRepository.Add(userMovie);
            }
        }

        public UserMovie GetExistingMovie(int movieId, string userId)
        {
            var userMovie = _userMovieRepository.Get().ToList()
                .Find(m => m.MovieId == movieId && m.UserId == userId);
            return userMovie;
        }

        public IEnumerable<UserMovie> GetFavouriteMovies(string userId)
        {
            var userMovieList = _userMovieRepository.GetUserMoviesIncludedMovies()
                .Where(u=>u.UserId==userId);
            return userMovieList;
        }

    }
}
