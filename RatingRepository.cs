using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
