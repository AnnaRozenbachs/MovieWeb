namespace MovieWeb.Models
{
    public class UserMovie
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }

        public string UserId { get; set; }

        public int MovieId { get; set; }

    }
}
