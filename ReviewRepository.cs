using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
