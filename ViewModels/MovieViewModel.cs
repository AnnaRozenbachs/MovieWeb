﻿namespace MovieWeb.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile? File { get; set; }

        public int CategoryId { get; set; }
    }
}
