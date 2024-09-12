using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Models
{
    public class SearchModel
    {
        [FromQuery(Name = "searchValue")]
        public string Search { get; set; }

        [FromQuery(Name = "categoryId")]
        public int CategoryId { get; set; }
    }
}
