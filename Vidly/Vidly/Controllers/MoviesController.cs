using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        [Route("Movies")]
        public ActionResult Movies()
        {
            var movielist = _context.Movies.Include(m => m.Genre).ToList();

            var viewModel = new MovieViewModel
            {
                MovieList = movielist
            };

            return View(viewModel);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var movielist = _context.Movies.Include(m => m.Genre).ToList();

            if (movielist == null)
            {
                return HttpNotFound();
            }
            else
            {
                var movie = movielist.Find(c => c.Id == id);

                var viewModel = new MovieDetailViewModel
                {
                    Name = movie.Name,
                    Genre = movie.Genre,
                    ReleaseDate = movie.ReleaseDate,
                    DateAdded = movie.DateAdded,
                    NumberInStock = movie.NumberInStock
                };

                return View(viewModel);
            }
        }
    }
}
