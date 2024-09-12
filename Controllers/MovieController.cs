using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieWeb.Extensions;
using MovieWeb.Models;
using MovieWeb.Service;
using MovieWeb.ViewModels;
using System.Security.Claims;

namespace MovieWeb.Controllers
{
    public class MovieController : PaginationBaseController
    {
        private IMovieService _movieService;
        private IFileService _fileService;
        private IPaginationService<Movie> _paginationService;
        private IUserMovieService _userMovieService;

        public MovieController(IMovieService movieService,IFileService fileService, IPaginationService<Movie> paginationService, IUserMovieService userMovieService) 
        {
            _movieService = movieService;
            _fileService = fileService; 
            _paginationService = paginationService;
            _userMovieService = userMovieService;
        }

        public IActionResult Index(string searchValue,int categoryId)
        {
            var movieList = _movieService.GetMovieList(searchValue, categoryId);
            var totalPerPage = Pagination<Movie>.TotalPerPage;

            var model = new MovieListViewModel
            {
                SearchModel = new SearchModel
                {
                    CategoryId = categoryId,
                    Search = searchValue
                },
                PaginationModel = new Pagination<Movie>
                {
                    TotalPages = Math.Ceiling((decimal)movieList.Count() / totalPerPage),
                    ActionName = nameof(Index),
                    ControllerName = nameof(Movie),
                    CurrentPage = page,
                    CurrentPageList = _paginationService.GetCurrentPage(movieList, page),
                    TotalResult = movieList.Count()
                    
                }
                
            };
            return View(model);
        }

        public IActionResult AddToFavourites(Dictionary<string, string> data)
        {
            var parameters = data.Where(k => !k.Key.Contains("movieId")).ToDictionary();    
            var userId = User.UserId();
            if (userId is null)
            {
                return NotFound();
            }
            _userMovieService.AddMovieToFavourites(int.Parse(data["movieId"]), userId);
            return RedirectToAction(nameof(Index), parameters);
            
        }

        public IActionResult CreateEdit(int id)
        {
            var model = new MovieViewModel();

            var movie = _movieService.GetMovieById(id);

            if(movie is not null) 
            {
                model.Id = movie.Id;
                model.Title = movie.Title;
                model.Description = movie.Description;
                model.CategoryId = movie.CategoryId;
                model.File = !string.IsNullOrEmpty(movie.ImageUrl) ? _fileService.GetFile(movie.ImageUrl) : null; 
            }          
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEdit(MovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id > 0)
            {
                var movie = _movieService.GetMovieById(model.Id);

                if (movie is null)
                {
                    return NotFound();
                }
                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.CategoryId = model.CategoryId;
                movie.ImageUrl = model.File is not null ? model.File.FileName : movie.ImageUrl;
                _movieService.UpdateMovie(movie);
                             
            }
            else 
            {
                var movie = new Movie(model.Id)
                {
                    Title = model.Title,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.File is not null ? model.File.FileName : null
                };
                _movieService.AddMovie(movie);
            }

            if (model.File is not null)
            {
                _fileService.UploadFile(model.File);
            }

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var movie = _movieService.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            _movieService.DeleteMovie(movie);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
            
        }
    }
}
