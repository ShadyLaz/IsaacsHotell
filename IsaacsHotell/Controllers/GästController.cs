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
    public class GästController : Controller
    {
        private readonly HotellDbContext _context;

        public GästController(HotellDbContext context)
        {
            _context = context;
        }

        // GET: Gäst
        public async Task<IActionResult> Index()
        {
            var hotellDbContext = _context.Gäster.Include(g => g.Order);
            return View(await hotellDbContext.ToListAsync());
        }

        // GET: Gäst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gäst = await _context.Gäster
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gäst == null)
            {
                return NotFound();
            }

            return View(gäst);
        }

        // GET: Gäst/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Ordrar, "Id", "Id");
            return View();
        }

        // POST: Gäst/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Förnamn,Efternamn,BokningId,OrderId")] Gäst gäst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gäst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Ordrar, "Id", "Id", gäst.OrderId);
            return View(gäst);
        }

        // GET: Gäst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gäst = await _context.Gäster.FindAsync(id);
            if (gäst == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Ordrar, "Id", "Id", gäst.OrderId);
            return View(gäst);
        }

        // POST: Gäst/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Förnamn,Efternamn,BokningId,OrderId")] Gäst gäst)
        {
            if (id != gäst.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gäst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GästExists(gäst.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Ordrar, "Id", "Id", gäst.OrderId);
            return View(gäst);
        }

        // GET: Gäst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gäst = await _context.Gäster
                .Include(g => g.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gäst == null)
            {
                return NotFound();
            }

            return View(gäst);
        }

        // POST: Gäst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gäst = await _context.Gäster.FindAsync(id);
            _context.Gäster.Remove(gäst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GästExists(int id)
        {
            return _context.Gäster.Any(e => e.Id == id);
        }
    }
}
