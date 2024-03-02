using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Stripe;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookingFacility.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "Enter your Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter your Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
           ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Payment Date")]
        public DateTime PaymentDate { get; set; }

     
    }
}
