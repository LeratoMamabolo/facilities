using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookingFacility.Models
{
    public class Product
    {
     
         public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product code.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a product price.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public decimal DiscountPercent => .5M; 

        public decimal DiscountAmount => Price * DiscountPercent;

        public decimal DiscountPrice => Price - DiscountAmount;

        public string Slug
        {
            get
            {
                if (Name == null)
                    return "";
                else
                    return Name.Replace(' ', '-');
            }
        }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; } 

        //Navigation properties working
        public Category Category { get; set; }
    }
}
