using Microsoft.AspNetCore.Identity;

namespace MovieWeb.Models
{
    public class Movie
    {
        public Movie(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public List<UserMovie> UserMovies { get; set; }

    }
}
