using Microsoft.EntityFrameworkCore;
using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Work> Works { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Book> Bookings { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Payment> Paymentss { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Work>().ToTable("Work");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Manager>().ToTable("Manager");

        }
        
    }
}
