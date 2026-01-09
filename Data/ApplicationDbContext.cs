using Microsoft.EntityFrameworkCore;
using Vidly.Models;
namespace Vidly.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "The Hangover",
                    Genre = "Comedy",
                    ReleaseDate = new DateTime(2004, 9, 23),
                    DateAdded = new DateTime(2024, 1, 1),
                    InStock = 5
                },
                new Movie
                {
                    Id = 2,
                    Name = "Die Hard",
                    Genre = "Action",
                    ReleaseDate = new DateTime(1994, 12, 25),
                    DateAdded = new DateTime(2021, 11, 4),
                    InStock = 6
                },
                new Movie
                {
                    Id = 3,
                    Name = "The Terminator",
                    Genre = "Action",
                    ReleaseDate = new DateTime(1984, 4, 12),
                    DateAdded = new DateTime(2020, 2, 13),
                    InStock = 3
                },
                new Movie 
                { 
                    Id = 4, 
                    Name = "Toy Story", 
                    Genre = "Animation",
                    ReleaseDate = new DateTime(1995, 11, 22),
                    DateAdded = new DateTime(2024, 1, 1),
                    InStock = 6
                },
                new Movie 
                { 
                    Id = 5, 
                    Name = "Titanic", 
                    Genre = "Romance",
                    ReleaseDate = new DateTime(1997, 12, 19),
                    DateAdded = new DateTime(2024, 1, 1),
                    InStock = 4
                }

            );
        }

        // Add your DbSet properties here
        // Example:
        // public DbSet<Customer> Customers { get; set; }
        // public DbSet<Movie> Movies { get; set; }
    }
}