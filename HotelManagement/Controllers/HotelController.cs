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
    public class HotelController : Controller
    {
        private readonly HotelManagementContext _context;

        public HotelController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: Hotel
        public async Task<IActionResult> Index()
        {
              return _context.AmenityMapping != null ? 
                          View(await _context.AmenityMapping.ToListAsync()) :
                          Problem("Entity set 'HotelManagementContext.AmenityMapping'  is null.");
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.AmenityMapping == null)
            {
                return NotFound();
            }

            var amenityMapping = await _context.AmenityMapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenityMapping == null)
            {
                return NotFound();
            }

            return View(amenityMapping);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,RoomTypeId")] AmenityMapping amenityMapping)
        {
            if (ModelState.IsValid)
            {
                amenityMapping.Id = Guid.NewGuid();
                _context.Add(amenityMapping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amenityMapping);
        }

        // GET: Hotel/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.AmenityMapping == null)
            {
                return NotFound();
            }

            var amenityMapping = await _context.AmenityMapping.FindAsync(id);
            if (amenityMapping == null)
            {
                return NotFound();
            }
            return View(amenityMapping);
        }

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,RoomTypeId")] AmenityMapping amenityMapping)
        {
            if (id != amenityMapping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amenityMapping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmenityMappingExists(amenityMapping.Id))
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
            return View(amenityMapping);
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.AmenityMapping == null)
            {
                return NotFound();
            }

            var amenityMapping = await _context.AmenityMapping
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amenityMapping == null)
            {
                return NotFound();
            }

            return View(amenityMapping);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.AmenityMapping == null)
            {
                return Problem("Entity set 'HotelManagementContext.AmenityMapping'  is null.");
            }
            var amenityMapping = await _context.AmenityMapping.FindAsync(id);
            if (amenityMapping != null)
            {
                _context.AmenityMapping.Remove(amenityMapping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmenityMappingExists(Guid id)
        {
          return (_context.AmenityMapping?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
