using MovieWeb.Models;
using MovieWeb.ViewModels;

namespace MovieWeb.Extensions
{
    public static class ModelExtensions
    {
        public static Dictionary<string, string> RouteValues(this Movie movie, MovieListViewModel model, string userId)
        {
            return new Dictionary<string, string>
            {
                {"page", model.PaginationModel.CurrentPage.ToString() },
                {"userMovieId", movie.Id.UserMovieId(movie.UserMovies, userId).ToString() },
                {"movieId", movie.Id.ToString() },
                {"categoryId", model.SearchModel.CategoryId.ToString() },
                {"searchValue", model.SearchModel.Search }
            };
        }
    }
}
