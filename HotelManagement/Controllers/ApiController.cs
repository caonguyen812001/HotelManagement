using HotelManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Components.Routing;
using HotelManagement.Models.HotelManagement;

namespace HotelManagement.Controllers;
[Route("api")]
public class ApiController : Controller
{
    private readonly HotelManagementContext _context;

    public ApiController(HotelManagementContext context)
    {
        _context = context;
    }
    
    [Route("/create-room-type")]
    public IActionResult CreateRoomType([FromBody]RoomType request)
    {
        if (_context.RoomType != null) _context.RoomType.Add(request);
        _context.SaveChanges();
        return Ok();
    }
    [Route("/get-all-room-type")]
    public IActionResult GetRoomType([FromBody] RoomType request)
    {
        if (_context.RoomType != null)
        {
            var result = _context.RoomType.FirstOrDefault();
            return result == null ? NotFound() : Ok(result);
        }

        return Ok();
    }
}