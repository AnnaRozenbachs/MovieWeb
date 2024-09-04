using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace MovieWeb.Models
{
    public class Pagination<T> :IPagination
    {
        public static int TotalPerPage { get => 8; }
        public IEnumerable<T> CurrentPageList { get; set; }
        public decimal TotalPages { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int CurrentPage { get; set; }
        public int TotalResult { get; set; }
    }
}
