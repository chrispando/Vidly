using System.ComponentModel.Design;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [Route("movies")]
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        [HttpGet("random")]
        public ActionResult Random()
        {

            var movie = new Movie() {Name = "Shrek!"};

            var customers = new List<Customer>() 
            { 
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"} 
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers,
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
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
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


    }
}
