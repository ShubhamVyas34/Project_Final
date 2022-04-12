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
    public class TravellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravellersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Travellers
        public async Task<IActionResult> Index()
        {
            return View(await _context.traveller.ToListAsync());
        }

        // GET: Travellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.traveller
                .FirstOrDefaultAsync(m => m.travellerId == id);
            if (traveller == null)
            {
                return NotFound();
            }

            return View(traveller);
        }

        // GET: Travellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("travellerId,name,age,contact,email,gender")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traveller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(traveller);
        }

        // GET: Travellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.traveller.FindAsync(id);
            if (traveller == null)
            {
                return NotFound();
            }
            return View(traveller);
        }

        // POST: Travellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("travellerId,name,age,contact,email,gender")] Traveller traveller)
        {
            if (id != traveller.travellerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traveller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravellerExists(traveller.travellerId))
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
            return View(traveller);
        }

        // GET: Travellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveller = await _context.traveller
                .FirstOrDefaultAsync(m => m.travellerId == id);
            if (traveller == null)
            {
                return NotFound();
            }

            return View(traveller);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traveller = await _context.traveller.FindAsync(id);
            _context.traveller.Remove(traveller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravellerExists(int id)
        {
            return _context.traveller.Any(e => e.travellerId == id);
        }
    }
}
