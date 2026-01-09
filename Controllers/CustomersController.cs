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
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
         List<Customer> customers = new List<Customer>() 
            { 
                new Customer {Name = "John Smith", Id=1},
                new Customer {Name = "Mary Williams", Id=2} 
            };
        // GET: CustomersController
        public ActionResult Index()
        {
            
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            Customer customer = customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return BadRequest("Customer ID not valid.");
            }
            return View(customer);
        }

    }
}
