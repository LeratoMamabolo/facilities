using Microsoft.AspNetCore.Mvc;

namespace OnlineBookingFacility.Controllers
{
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
