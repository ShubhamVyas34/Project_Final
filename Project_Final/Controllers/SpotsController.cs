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
    public class SpotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spots
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.spots.Include(s => s.traveller);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Spots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spots = await _context.spots
                .Include(s => s.traveller)
                .FirstOrDefaultAsync(m => m.spotId == id);
            if (spots == null)
            {
                return NotFound();
            }

            return View(spots);
        }

        // GET: Spots/Create
        public IActionResult Create()
        {
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId");
            return View();
        }

        // POST: Spots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("spotId,travellerId,spotName,spotLocation,spotDescription")] Spots spots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", spots.travellerId);
            return View(spots);
        }

        // GET: Spots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spots = await _context.spots.FindAsync(id);
            if (spots == null)
            {
                return NotFound();
            }
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", spots.travellerId);
            return View(spots);
        }

        // POST: Spots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("spotId,travellerId,spotName,spotLocation,spotDescription")] Spots spots)
        {
            if (id != spots.spotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotsExists(spots.spotId))
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
            ViewData["travellerId"] = new SelectList(_context.traveller, "travellerId", "travellerId", spots.travellerId);
            return View(spots);
        }

        // GET: Spots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spots = await _context.spots
                .Include(s => s.traveller)
                .FirstOrDefaultAsync(m => m.spotId == id);
            if (spots == null)
            {
                return NotFound();
            }

            return View(spots);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spots = await _context.spots.FindAsync(id);
            _context.spots.Remove(spots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotsExists(int id)
        {
            return _context.spots.Any(e => e.spotId == id);
        }
    }
}
