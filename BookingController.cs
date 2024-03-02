using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using OnlineBookingFacility.Models;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace OnlineBookingFacility.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public BookingController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private int amount = 100;
        public IActionResult Index()
        {
            ViewBag.PaymentAmount = amount;
            return View();
        }

        [HttpPost]
        public IActionResult Processing(string stripeToken, string stripeEmail)
        {
            Dictionary<string, string> Metadata = new Dictionary<string, string>();
            Metadata.Add("Product", "FacilityBooking");
            Metadata.Add("Quantity", "10");
            var options = new ChargeCreateOptions
            {
                Amount = amount,
                Currency = "USD",
                Description = "Payment",
                Source = stripeToken,
                ReceiptEmail = stripeEmail,
                Metadata = Metadata
            };
            var service = new ChargeService();
            Charge charge = service.Create(options);
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "test paymentxx",
                Currency = "usd",
                Customer = customer.Id
            });


            if (charge.Status == "succeeded")
            {
                string BalanceTransactionId = charge.BalanceTransactionId;
                return View();
            }
            else
            {

            }

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GeneratePDF()
        {
            // Create a new document
            Document doc = new Document();

            // Create a memory stream to store the PDF content
            MemoryStream memoryStream = new MemoryStream();

            // Create a PdfWriter to write the PDF to the memory stream
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();

            // Add content to the PDF
            // For example, you can add text, images, tables, etc.
            doc.Add(new Paragraph("Hello, this is your booking PDF!"));

            doc.Close();

            // Set the response headers for the PDF file
            Response.Headers.Add("Content-Disposition", "attachment; filename=booking.pdf");
            Response.Headers.Add("Content-Type", "application/pdf");

            // Write the PDF content to the response output stream
            Response.Body.WriteAsync(memoryStream.ToArray());

            return new EmptyResult(); // Return an empty result, as the PDF is sent in the response stream
        }
    }  
    
}

