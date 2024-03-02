using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Data
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAllProductsInCategory(string category);
        IEnumerable<Product> GetAllProductsWithCategoryDetails();

    }
}
