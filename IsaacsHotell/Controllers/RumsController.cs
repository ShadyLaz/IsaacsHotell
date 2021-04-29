using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacsHotell.Data;
using IsaacsHotell.Models;

namespace IsaacsHotell.Controllers
{
    public class RumsController : Controller
    {
        private readonly HotellDbContext _context;

        public RumsController(HotellDbContext context)
        {
            _context = context;
        }

        // GET: Rums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rum.ToListAsync());
        }

        // GET: Rums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rum = await _context.Rum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rum == null)
            {
                return NotFound();
            }

            return View(rum);
        }

        // GET: Rums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namn,Antalsovplatser,Smutsigt,BokningId")] Rum rum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rum);
        }

        // GET: Rums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rum = await _context.Rum.FindAsync(id);
            if (rum == null)
            {
                return NotFound();
            }
            return View(rum);
        }

        // POST: Rums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namn,Antalsovplatser,Smutsigt,BokningId")] Rum rum)
        {
            if (id != rum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RumExists(rum.Id))
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
            return View(rum);
        }

        // GET: Rums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rum = await _context.Rum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rum == null)
            {
                return NotFound();
            }

            return View(rum);
        }

        // POST: Rums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rum = await _context.Rum.FindAsync(id);
            _context.Rum.Remove(rum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RumExists(int id)
        {
            return _context.Rum.Any(e => e.Id == id);
        }
    }
}
