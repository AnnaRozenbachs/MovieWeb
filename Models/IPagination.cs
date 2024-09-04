namespace MovieWeb.Models
{
    public interface IPagination
    {
        public decimal TotalPages { get; set; }

        public static int TotalPerPage { get; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public int CurrentPage { get; set; }

        public int TotalResult { get; set; }
    }
}
