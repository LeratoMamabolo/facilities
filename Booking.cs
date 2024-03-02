using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookingFacility.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }
        [Required]
        [DisplayName("Price")]
        public DateTime Price { get; set; }
    }
}
