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
    public class RoomTypeMappingController : Controller
    {
        private readonly HotelManagementContext _context;

        public RoomTypeMappingController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: RoomTypeMapping
        public async Task<IActionResult> Index()
        {
              return _context.RoomTypeMapping != null ? 
                          View(await _context.RoomTypeMapping.ToListAsync()) :
                          Problem("Entity set 'HotelManagementContext.RoomTypeMapping'  is null.");
        }

        // GET: RoomTypeMapping/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RoomTypeMapping == null)
            {
                return NotFound();
            }

            var roomTypeMapping = await _context.RoomTypeMapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomTypeMapping == null)
            {
                return NotFound();
            }

            return View(roomTypeMapping);
        }

        // GET: RoomTypeMapping/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomTypeMapping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomTypeCount")] RoomTypeMapping roomTypeMapping)
        {
            if (ModelState.IsValid)
            {
                roomTypeMapping.Id = Guid.NewGuid();
                _context.Add(roomTypeMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomTypeMapping);
        }

        // GET: RoomTypeMapping/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RoomTypeMapping == null)
            {
                return NotFound();
            }

            var roomTypeMapping = await _context.RoomTypeMapping.FindAsync(id);
            if (roomTypeMapping == null)
            {
                return NotFound();
            }
            return View(roomTypeMapping);
        }

        // POST: RoomTypeMapping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RoomTypeCount")] RoomTypeMapping roomTypeMapping)
        {
            if (id != roomTypeMapping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomTypeMapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomTypeMappingExists(roomTypeMapping.Id))
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
            return View(roomTypeMapping);
        }

        // GET: RoomTypeMapping/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RoomTypeMapping == null)
            {
                return NotFound();
            }

            var roomTypeMapping = await _context.RoomTypeMapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomTypeMapping == null)
            {
                return NotFound();
            }

            return View(roomTypeMapping);
        }

        // POST: RoomTypeMapping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RoomTypeMapping == null)
            {
                return Problem("Entity set 'HotelManagementContext.RoomTypeMapping'  is null.");
            }
            var roomTypeMapping = await _context.RoomTypeMapping.FindAsync(id);
            if (roomTypeMapping != null)
            {
                _context.RoomTypeMapping.Remove(roomTypeMapping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomTypeMappingExists(Guid id)
        {
          return (_context.RoomTypeMapping?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
