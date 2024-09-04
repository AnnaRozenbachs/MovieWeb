using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.ViewModels
{
    public class FavouriteViewModel
    {
        [FromQuery(Name ="page")]
        public string Page { get; set; }

        [FromQuery(Name = "userMovieId")]
        public string UserMovieId { get; set; }

        [FromQuery(Name = "movieId")]
        public string MovieId { get; set; }

        [FromQuery(Name = "categoryId")]
        public string CategoryId { get; set; }

        [FromQuery(Name = "searchValue")]
        public string SearchValue { get; set; }
    }
}
