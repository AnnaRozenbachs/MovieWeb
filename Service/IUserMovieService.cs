using MovieWeb.Models;

namespace MovieWeb.Service
{
    public interface IUserMovieService
    {
        public void AddMovieToFavourites(int movieId, string userId);

        public IEnumerable<UserMovie> GetFavouriteMovies(string userId);

        public UserMovie GetExistingMovie(int movieId, string userId);

    }
}
