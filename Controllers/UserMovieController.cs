using Microsoft.AspNetCore.Mvc;
using MovieWeb.Extensions;
using MovieWeb.Models;
using MovieWeb.Service;
using MovieWeb.ViewModels;

namespace MovieWeb.Controllers
{
    public class UserMovieController : PaginationBaseController
    {
        private IUserMovieService _userMovieService;
        private IPaginationService<UserMovie> _paginationService;

        public UserMovieController(IUserMovieService userMovieService, IPaginationService<UserMovie> paginationService)
        {
            _userMovieService = userMovieService;
            _paginationService = paginationService;
            
        }
        public IActionResult Index()
        {
            var favouriteMovies = _userMovieService.GetFavouriteMovies(User.UserId());
            var totalPages = Pagination<UserMovie>.TotalPerPage;

            var model = new FavouriteListViewModel
            {
                PaginationModel = new Pagination<UserMovie>()
                {
                    CurrentPageList = _paginationService.GetCurrentPage(favouriteMovies, page),
                    ControllerName = nameof(UserMovie),
                    ActionName= nameof(Index),
                    CurrentPage = page,
                    TotalResult = favouriteMovies.Count(),
                    TotalPages = Math.Ceiling((decimal)favouriteMovies.Count() / totalPages),
                }
            };
            return View(model);
        }
    }
}
