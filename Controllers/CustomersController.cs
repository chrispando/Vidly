using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
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
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
               
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return BadRequest("Customer ID not valid.");
            }
            return View(customer);
        }

    }
}
