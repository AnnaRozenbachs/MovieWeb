using MovieWeb.Models;

namespace MovieWeb.ViewModels
{
    public class MovieListViewModel
    {

        public SearchModel SearchModel { get; set; }

        public Pagination<Movie> PaginationModel { get; set; }

    }
}
