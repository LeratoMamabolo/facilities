using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
