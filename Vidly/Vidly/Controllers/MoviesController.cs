using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("Movies")]
        public ActionResult Movies()
        {
            List<Movie> movielist = new List<Movie>();
            movielist.Add(new Movie{ Name = "Shrek", Id = 1});
            movielist.Add(new Movie { Name = "Wall-e", Id = 2 });

            var viewModel = new MovieViewModel
            {
                MovieList = movielist
            };

            return View(viewModel);
        }

        /*[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }*/
    }
}
