using Microsoft.AspNetCore.Mvc;
using MovieWeb.Models;

namespace MovieWeb.ViewModels
{
    public class FavouriteViewModel
    {
        [FromQuery(Name ="page")]
        public string Page { get; set; }

        [FromQuery(Name = "movieId")]
        public string MovieId { get; set; }

        public SearchModel SearchModel { get; set; }
    }
}
