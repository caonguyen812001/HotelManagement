using HotelManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers;
[Route("start-search")]
public class StartSearch : Controller
{
    private readonly HotelManagementContext _context;

    public async Task<IActionResult> Index()
    {
        return View("SearchResultPage");
    }
}