

namespace OnlineBookingFacility.Data
{
    public interface IRepositoryWrapper
    {
        IManagerRepository Manager { get; }
        IWorkRepository Work { get; }

        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        IBookRepository Book { get; }

        IReviewRepository Review { get; }

        IPaymentRepository Payment { get; }

        IRatingRepository Rating { get; }
        void Save();
    }
}
