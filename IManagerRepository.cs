using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public interface IManagerRepository : IRepositoryBase<Manager>
    {
        Manager GetManagerWithEnrollmentDetails(int id);
    }
}
