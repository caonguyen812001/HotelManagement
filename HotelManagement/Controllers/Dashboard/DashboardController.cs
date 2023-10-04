using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.Dashboard;

[Microsoft.AspNetCore.Components.Route("dashboard")]
public class DashboardController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public DashboardController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EditHotel()
    {
        return View();
    }
}