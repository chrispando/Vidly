using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using Microsoft.EntityFrameworkCore;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: CustomersController
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
               
            Customer customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.Id == id);

            if(customer == null)
            {
                return BadRequest("Customer ID not valid.");
            }

            return View(customer);
        }

    }
}
