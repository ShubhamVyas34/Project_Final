using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Final.Data;
using Project_Final.Models;

namespace Project_Final.Controllers
{
    [Authorize]
    public class HotelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HotelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.hotels.Include(h => h.traveller);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.hotels
                .Include(h => h.traveller)
                .FirstOrDefaultAsync(m => m.hotelId == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hotelId,travellerId,hotelName,checkInDate,checkOutDate,noOfRooms")] Hotels hotels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", hotels.travellerId);
            return View(hotels);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.hotels.FindAsync(id);
            if (hotels == null)
            {
                return NotFound();
            }
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", hotels.travellerId);
            return View(hotels);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hotelId,travellerId,hotelName,checkInDate,checkOutDate,noOfRooms")] Hotels hotels)
        {
            if (id != hotels.hotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelsExists(hotels.hotelId))
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
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", hotels.travellerId);
            return View(hotels);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotels = await _context.hotels
                .Include(h => h.traveller)
                .FirstOrDefaultAsync(m => m.hotelId == id);
            if (hotels == null)
            {
                return NotFound();
            }

            return View(hotels);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotels = await _context.hotels.FindAsync(id);
            _context.hotels.Remove(hotels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelsExists(int id)
        {
            return _context.hotels.Any(e => e.hotelId == id);
        }
    }
}
