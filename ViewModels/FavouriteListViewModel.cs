using MovieWeb.Models;

namespace MovieWeb.ViewModels
{
    public class FavouriteListViewModel
    {
        public Pagination<UserMovie> PaginationModel { get; set; }
    }
}
