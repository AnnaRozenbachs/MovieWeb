using Microsoft.AspNetCore.Mvc;

namespace MovieWeb.Models
{
    public class SearchModel
    {
        public string Search { get; set; }

        [FromQuery(Name = "categoryId")]
        public int CategoryId { get; set; }
    }
}
