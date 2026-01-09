using Microsoft.EntityFrameworkCore;
using Vidly.Models;
namespace Vidly.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add your DbSet properties here
        // Example:
        // public DbSet<Customer> Customers { get; set; }
        // public DbSet<Movie> Movies { get; set; }
    }
}