using Microsoft.CodeAnalysis.CSharp.Syntax;
using MovieWeb.Models;
using Newtonsoft.Json;


namespace MovieWeb.Extensions
{
    public static class IntExtensions
    {
        public static string MovieExists(this int movieId, string userId, List<UserMovie> userMovieList)
        {
            return userMovieList
                .Exists(x => x.MovieId == movieId
                 && x.UserId == userId) ? "fa-solid" : "fa-regular";

        }

        public static int UserMovieId(this int movieId, List<UserMovie> userMovieList, string userId)
        {
            var userMovie = userMovieList.Find(u=>u.MovieId == movieId && u.UserId == userId);

            return userMovie is not null ? userMovie.Id : 0;
        }
    }
}
