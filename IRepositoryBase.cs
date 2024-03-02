using OnlineBookingFacility.Data.DataAccess;
using System.Linq.Expressions;

namespace OnlineBookingFacility.Data
{
    public interface IRepositoryBase<T>
    {
        T GetById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetWithOptions(QueryOptions<T> options);
    }
}
