using Microsoft.EntityFrameworkCore;
using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public class ManagerRepository : RepositoryBase<Manager>, IManagerRepository
    {
        public ManagerRepository(AppDbContext appDbContext)
                    : base(appDbContext)
        {
        }

        public Manager GetManagerWithEnrollmentDetails(int id)
        {
            return _appDbContext.Managers
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Work)
                .FirstOrDefault(s => s.ManagerID == id);
        }
    }
}
