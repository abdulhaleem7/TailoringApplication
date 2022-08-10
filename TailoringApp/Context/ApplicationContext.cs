using Microsoft.EntityFrameworkCore;
using TailoringApp.Entity;
using TailoringApp.Identity;

namespace TailoringApp.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Cloth> Cloths { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Colour> Colours { get; set; }

        public DbSet<Design> Designs { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<OrderMeasurement> OrderMeasurements { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Payment> payments { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
