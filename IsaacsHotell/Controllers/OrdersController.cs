using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacsHotell.Data;
using IsaacsHotell.Models;
using Microsoft.AspNetCore.Identity;
using System.Web;

namespace IsaacsHotell.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HotellDbContext _context;
        private readonly UserManager<Användare> _userManager;
        private readonly SignInManager<Användare> _signInManager;

        public OrdersController(HotellDbContext context, UserManager<Användare> userManager, SignInManager<Användare> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task <IActionResult> Frukost()
        {
            //if(DateTime.Now => 18.00) fixa
            var user = await _userManager.GetUserAsync(User);
            var hittauserid = _context.Gäster.Where(x => x.Förnamn == user.Namn).Select(x => x.Id).ToList();

            var Frukost = new Order { Pris = 50, Produkt = "Frukost", GästId = hittauserid[0] };
            _context.Ordrar.Add(Frukost);
             await _context.SaveChangesAsync();


            //if (result.IsCompletedSuccessfully)
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Frukost är bokad tills imorgon!');</script>");
            
            return RedirectToAction("Thankyou", "Orders");
        }
        public ActionResult BokatFrukost()
        {
            TempData["alertMessage"] = "Tack för du bokat frukost";
            return View();
        }
        public async Task<IActionResult> UserOrder()
        {
            var user = await _userManager.GetUserAsync(User);
            var gästenorder = _context.Gäster.Where(x => x.Förnamn ==user.Namn).Select(x => x.Id).ToList();

            var ordrar = _context.Ordrar.Where(x => x.GästId == gästenorder[0]).ToList();
            //var gäst = _context.Gäster.Where(x => x.Förnamn == user.Namn).Select(x => x).ToList();


            return View(ordrar);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ordrar.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Ordrar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pris,GästId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Ordrar.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pris,GästId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Ordrar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Ordrar.FindAsync(id);
            _context.Ordrar.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Ordrar.Any(e => e.Id == id);
        }

    }
}
