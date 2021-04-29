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
    public class AnställdController : Controller
    {
        private readonly HotellDbContext _context;

        public AnställdController(HotellDbContext context)
        {
            _context = context;
        }

        // GET: Anställd
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anställda.ToListAsync());
        }

        // GET: Anställd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anställd = await _context.Anställda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anställd == null)
            {
                return NotFound();
            }

            return View(anställd);
        }

        // GET: Anställd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Anställd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Förnamn,Efternamn,Roll")] Anställd anställd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anställd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anställd);
        }

        // GET: Anställd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anställd = await _context.Anställda.FindAsync(id);
            if (anställd == null)
            {
                return NotFound();
            }
            return View(anställd);
        }

        // POST: Anställd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Förnamn,Efternamn,Roll")] Anställd anställd)
        {
            if (id != anställd.Id)
            {
                return NotFound(); 
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anställd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnställdExists(anställd.Id)) 
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
            return View(anställd);
        }

        // GET: Anställd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var anställd = await _context.Anställda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anställd == null)
            {
                return NotFound();
            }

            return View(anställd);
        }

        // POST: Anställd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anställd = await _context.Anställda.FindAsync(id);
            _context.Anställda.Remove(anställd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnställdExists(int id)
        {
            return _context.Anställda.Any(e => e.Id == id); 
        }
    }
}
