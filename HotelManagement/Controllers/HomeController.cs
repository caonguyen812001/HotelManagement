using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HotelManagement.Models.RequestResponseModel;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Route("start-search")]
        public IActionResult StartSearch(StartSearchRequest request)
        {
            return View();
        }
        
        [Route("room-detail")]
        public IActionResult GetRoomDetail()
        {
            return View();
        }
        
        [Route("create-booking")]
        public IActionResult Booking()
        {
            return View();
        }

        [Route("booking-now")]
        public IActionResult BookingNow()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}