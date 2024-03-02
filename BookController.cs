using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using OnlineBookingFacility.Data;
using OnlineBookingFacility.Models;

namespace OnlineBookingFacility.Controllers
{
    public class BookController : Controller
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public BookController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            book.BookDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Book.Add(book);
                TempData["Message"] = $" Thanks {book.Name},booking has been added";
                _repositoryWrapper.Save();
                return RedirectToAction("List");
            }
            else
            {
                return View(book);
            }
        }


        public IActionResult List()
        {
            var Booking = _repositoryWrapper.Book.FindAll().OrderBy(b => b.BookDate);
            return View(Booking);
        }

        public IActionResult ListPreviousBookings()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;

            // Query the repository to fetch previous bookings
            var previousBookings = _repositoryWrapper.Book
                .FindAll()
                .Where(b => b.EndDate < currentDate) // Filter past bookings
                .OrderBy(b => b.BookDate)
                .ToList();

            return View(previousBookings);
        }


    }
}
