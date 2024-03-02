using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineBookingFacility.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
          ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
        public int? Ratings { get; set; }

        [Required]
        [DisplayName("Rating Date")]
        public DateTime RatingDate { get; set; }

        [Required(ErrorMessage = "Please enter product Name.")]
        public string ProductName { get; set; }
       

    }
}
