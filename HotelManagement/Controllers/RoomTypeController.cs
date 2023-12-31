using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models.HotelManagement;

namespace HotelManagement.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly HotelManagementContext _context;

        public RoomTypeController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: RoomType
        public async Task<IActionResult> Index()
        {
              return _context.RoomType != null ? 
                          View(await _context.RoomType.ToListAsync()) :
                          Problem("Entity set 'HotelManagementContext.RoomType'  is null.");
        }

        // GET: RoomType/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RoomType == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // GET: RoomType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,NumberOfBed,ImageUrlsJsonString,PricePerNight")] RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                roomType.Id = Guid.NewGuid();
                _context.Add(roomType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomType/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RoomType == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return View(roomType);
        }

        // POST: RoomType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,NumberOfBed,ImageUrlsJsonString,PricePerNight")] RoomType roomType)
        {
            if (id != roomType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeExists(roomType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roomType);
        }

        // GET: RoomType/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RoomType == null)
            {
                return NotFound();
            }

            var roomType = await _context.RoomType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomType == null)
            {
                return NotFound();
            }

            return View(roomType);
        }

        // POST: RoomType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RoomType == null)
            {
                return Problem("Entity set 'HotelManagementContext.RoomType'  is null.");
            }
            var roomType = await _context.RoomType.FindAsync(id);
            if (roomType != null)
            {
                _context.RoomType.Remove(roomType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeExists(Guid id)
        {
          return (_context.RoomType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
