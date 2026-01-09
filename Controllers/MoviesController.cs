using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;
namespace Vidly.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;


        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random
        [HttpGet("random")]
        public ActionResult Random()
        {

            var movie = new Movie() {Name = "Shrek!"};

           

            var viewModel = new RandomMovieViewModel
            {
                
            } ;
            
            return View(viewModel);
            
        }
        [HttpGet("Edit")]
        public ActionResult Edit(int id)
        {
            return Content("id="+id);
        }

        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet("released")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            if(year < 1900 || year > DateTime.UtcNow.Year)
            {
                return BadRequest("Invalid year.");
            }
            if(month < 1 || month > 12)
            {
                return BadRequest("Invalid month.");
            }

            return Content($"{year:D4}/{month:D2}");
        }

        [HttpGet("detail")]
          public ActionResult Detail(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(m=>m.Id == id);

            if(movie == null)
            {
                return BadRequest("Movie ID not valid.");
            }

            return View(movie);
        }

    }
}
