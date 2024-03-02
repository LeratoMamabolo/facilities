using Microsoft.EntityFrameworkCore;
using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Managers.Any())
            {
                context.Managers.AddRange(
                    new Manager { Initials = "L", FirstName = "Lerato", LastName = "Mamabolo", EnrollmentDate = DateTime.Parse("2023-09-01") },
                    new Manager { Initials = "M", FirstName = "Mary", LastName = "Holmes", EnrollmentDate = DateTime.Parse("2023-05-21") },
                    new Manager { Initials = "M", FirstName = "Moses", LastName = "Johnes", EnrollmentDate = DateTime.Parse("2023-09-02") },
                    new Manager { Initials = "D", FirstName = "Dave", LastName = "Smith", EnrollmentDate = DateTime.Parse("2023-09-11") }

                    );
            }

            if (!context.Works.Any())
            {
                context.Works.AddRange(
                    new Work { WorkID = 1050, Title = "Gym", Points = 8 },
                    new Work { WorkID = 4022, Title = "LaundryServices", Points = 10 },
                    new Work { WorkID = 4041, Title = "Parking", Points = 9 }
                    
                    );
            }

            if (!context.Enrollments.Any())
            {
                context.Enrollments.AddRange(
                    new Enrollment { ManagerID = 1, WorkID = 1050, Performance = Performance.Excellent},
                    new Enrollment { ManagerID = 1, WorkID = 4022, Performance = Performance.Satisfactory},
                    new Enrollment { ManagerID = 3, WorkID = 1050 },
                    new Enrollment { ManagerID = 4, WorkID = 1050 },
                    new Enrollment { ManagerID = 4, WorkID = 4022, Performance = Performance.Good }
                   
                    );
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Gym" },
                    new Category { CategoryName = "LaundyService" },
                    new Category { CategoryName = "Parkingservice" },
                    new Category { CategoryName = "librarydiscussionroom" }
                    );
            }


            
            context.SaveChanges();
        }
    }
}
