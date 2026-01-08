using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
namespace MyApp.Namespace
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie() {Name = "Shrek!"};
            return View(movie);
        }



    }
}
