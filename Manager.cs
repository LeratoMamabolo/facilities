using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookingFacility.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }

        [DisplayName("Last name")]
        [Required(ErrorMessage = "Enter a last name")]
        public string LastName { get; set; }

        [DisplayName("First name")]
        [Required(ErrorMessage = "Enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter initials")]
        public string Initials { get; set; }

        [DisplayName("Enrollment date")]
        [Required]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
