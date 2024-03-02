
namespace OnlineBookingFacility.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext _appDbContext;
        private IManagerRepository _manager;
        private IWorkRepository _work;
        private IProductRepository _product;
        private ICategoryRepository _category;
        private IBookRepository _book;
        private IReviewRepository _review;
        private IPaymentRepository _payment;
        private IRatingRepository _rating;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IManagerRepository Manager
        {
            get
            {
                if (_manager == null)
                {
                    _manager = new ManagerRepository(_appDbContext);
                }

                return _manager;
            }
        }

        public IWorkRepository Work
        {
            get
            {
                if (_work == null)
                {
                    _work = new WorkRepository(_appDbContext);
                }

                return _work;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_appDbContext);
                }
                return _product;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_appDbContext);
                }
                return _category;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_appDbContext);
                }
                return _book;
            }
        }

        public IReviewRepository Review
        {
            get
            {
                if (_review == null)
                {
                    _review = new ReviewRepository(_appDbContext);
                }
                return _review;
            }
        }

        public IPaymentRepository Payment
        {
            get
            {
                if (_payment == null)
                {
                    _payment = new PaymentRepository(_appDbContext);
                }
                return _payment;
            }
        }

        public IRatingRepository Rating
        {
            get
            {
                if (_rating == null)
                {
                    _rating = new RatingRepository(_appDbContext);
                }
                return _rating;
            }
        }
        public void Save()
        {
            _appDbContext.SaveChanges();
        }
    }
}
