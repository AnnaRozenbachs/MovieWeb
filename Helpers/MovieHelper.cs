using MovieWeb.Models;
using MovieWeb.ViewModels;


namespace MovieWeb.Helpers
{
    public  class MovieHelper 
    {
        public static string IsInFavourites(int movieId, string userId, List<UserMovie> userMovieList)
        {
            return userMovieList
                .Exists(x => x.MovieId == movieId
                 && x.UserId == userId) ? "fa-solid" : "fa-regular";
        }

        public static Dictionary<string, string> RouteValues(MovieListViewModel model, int movieId)
        {
            var data = new Dictionary<string, string>
            {
                {"page", model.PaginationModel.CurrentPage.ToString() },
                {"searchValue", model.SearchModel.Search },
                {"movieId", movieId.ToString() },
            };

            if (model.SearchModel.CategoryId > 0)
            {
                data.Add("categoryId", model.SearchModel.CategoryId.ToString());
            }
            return data;
        }
    }
}
