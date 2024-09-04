using MovieWeb.Models;

namespace MovieWeb.Service
{
    public interface IUserMovieService
    {
        public void AddMovieToFavourites(int userMovieId, int movieId, string userId);

    }
}
