using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
