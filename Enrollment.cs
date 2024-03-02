using Stripe;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookingFacility.Models
{
    public enum Performance
    {
        Excellent, Good, Bad, Average, Satisfactory
    }

    public class Enrollment
    {
       public int EnrollmentID { get; set; }
        public int WorkID { get; set; }
        public int ManagerID { get; set; }
        public Performance? Performance { get; set; }

        public Work Work { get; set; }
        public Manager Manager { get; set; }
    }
}
