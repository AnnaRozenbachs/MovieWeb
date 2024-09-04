using MovieWeb.Models;
using MovieWeb.Repository;

namespace MovieWeb.Service
{
    public class UserMovieService : IUserMovieService
    {
        private IRepository<UserMovie> _userMovieRepository;
        public UserMovieService(IRepository<UserMovie> userMovieRepository)
        {
            _userMovieRepository = userMovieRepository;
        }
        public void AddMovieToFavourites(int userMovieId, int movieId, string userId)
        {
            if (userMovieId > 0)
            {
                var userMovie = _userMovieRepository.GetById(userMovieId);
                _userMovieRepository.Delete(userMovie);
            }
            else
            {
                var userMovie = new UserMovie
                {
                    UserId = userId,
                    MovieId = movieId
                };
                _userMovieRepository.Add(userMovie);
            }
        }

    }
}
