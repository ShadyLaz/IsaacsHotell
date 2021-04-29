using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IsaacsHotell.Data;
using IsaacsHotell.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace IsaacsHotell.Controllers
{
    [Authorize]
    public class BokningsController : Controller
    {
        private readonly HotellDbContext _context;
        private readonly UserManager<Användare> _userManager;
        private readonly SignInManager<Användare> _signInManager;

        public BokningsController(HotellDbContext context, UserManager<Användare> userManager, SignInManager<Användare> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Boknings
        public async Task<IActionResult> Index()
        {
            var hotellDbContext = _context.Bokningar.Include(b => b.Gäst).Include(b => b.Rum);
            return View(await hotellDbContext.ToListAsync());
        }

        // GET: Boknings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar
                .Include(b => b.Gäst)
                .Include(b => b.Rum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bokning == null)
            {
                return NotFound();
            }

            return View(bokning);
        }

        // GET: Boknings/Create
        public IActionResult Create()
        {
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "");
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id");
            return View();
        }

        // POST: Boknings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Incheckning,Utcheckning,GästId,RumId")] Bokning bokning)
        {
            if (ModelState.IsValid) //kommer inte in här när jag försöker skapa. Nått med relationen i db som är fuckad
            {
                _context.Add(bokning);
                //här kanske det måste uppdateras i Gästen också
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // GET: Boknings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar.FindAsync(id);
            if (bokning == null)
            {
                return NotFound();
            }
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // POST: Boknings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Incheckning,Utcheckning,GästId,RumId")] Bokning bokning)
        {
            if (id != bokning.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bokning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BokningExists(bokning.Id))
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
            ViewData["GästId"] = new SelectList(_context.Gäster, "Id", "Id", bokning.GästId);
            ViewData["RumId"] = new SelectList(_context.Rum, "Id", "Id", bokning.RumId);
            return View(bokning);
        }

        // GET: Boknings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bokning = await _context.Bokningar
                .Include(b => b.Gäst)
                .Include(b => b.Rum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bokning == null)
            {
                return NotFound();
            }

            return View(bokning);
        }

        // POST: Boknings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bokning = await _context.Bokningar.FindAsync(id);
            _context.Bokningar.Remove(bokning);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CheckFreeRooms()
        {
            return View();
        }

    
        //KONTROLLERAR OM DET FINNS LEDIGA RUM
        public async Task<IActionResult> LookForAvailableRooms(DateTime BookFrom, DateTime BookTo, int NoOfMembers, Rum Rum)
        {
           
            //var usergäst = new Gäst();
            var allarum = _context.Rum.Select(x => x).ToList();
            var allaupptagnarum = _context.Bokningar.Where(x => x.Incheckning <= BookFrom && x.Utcheckning >= BookTo)
                                            .Select(x => x.Rum).ToList();

            var upptagnaplatser = allaupptagnarum.Select(x => x.Antalsovplatser).Sum();
            var totalaplatser = allarum.Select(x => x.Antalsovplatser).Sum();

            //var user = await _userManager.GetUserAsync(User);

            if (totalaplatser - upptagnaplatser >= NoOfMembers) // kollar om det finns plats de datumen
            { 


                allarum.RemoveAll(x => allaupptagnarum.Exists(y => y.Id == x.Id));  //Tar bort alla upptagna rum från listan. kvar är rummen som kan bli bokade
                var aktuelltbokninsrum = allarum.FirstOrDefault(x => x.Antalsovplatser == NoOfMembers);



                //var nybokning = new Bokning { Gäst = usergäst, Incheckning = BookFrom, Utcheckning = BookTo, Rum = aktuelltbokninsrum };

                var nätter = (BookTo - BookFrom).TotalDays;
                var totalkostnad = nätter * aktuelltbokninsrum.PrisPerNatt;

                ViewBag.Rumsinfo = "Vi hittade det perfekta rummet för dig, totalt: " + nätter + " " + "nätter, för den totala kostnaden: "+ totalkostnad + "kr"+" , Ska du slå till?"; 

                ViewBag.bookfrom = BookFrom;
                ViewBag.bookto = BookTo;
                ViewBag.noofmembers = NoOfMembers;
                ViewBag.Room = aktuelltbokninsrum.Id;
                ViewBag.antnätter = nätter;
                ViewBag.kostnad = totalkostnad;

                return View();
            }
            else
            {
                ViewBag.Errormessage = "Det verkar som alla rummen är upptagna. Försök med ett annat datum!";
                return View();
            }
          

        }
        //SKAPAR BOKNINGEN
        public async Task<IActionResult> ConfirmTheBooking(DateTime _BookFrom, DateTime _BookTo, int _NoOfMembers, int _RoomId, int _nätter, double _kostnad)
        {

            var usergäst = new Gäst();
            var user = await _userManager.GetUserAsync(User);

            //var resultgäst = _context.Gäster.Where(x => x.Förnamn == user.Namn).Select(x => x).ToList();
            //if (!resultgäst.Any()) // if sats för att undivka dubbletter i db
            //{
                //var nygäst = new Gäst { Förnamn = user.Namn, Efternamn = user.Efternamn };

                //await _context.Gäster.AddAsync(nygäst);
                //await _context.SaveChangesAsync();

                var gäst = _context.Gäster.Where(x => x.Förnamn == user.Namn).Select(x => x).ToList();
                usergäst = gäst[0];
            //}
            //else
            //{
            //    usergäst = resultgäst[0];
            //}
           
            var nybokning = new Bokning { Gäst = usergäst, Incheckning = _BookFrom, Utcheckning = _BookTo, RumId = _RoomId };

            
            await _context.Bokningar.AddAsync(nybokning);
            await _context.SaveChangesAsync();
            //slänga in bokningsid på gästen
            //slänga in order id på gästen


            var gästbookning =  _context.Gäster.Where(x => x.Förnamn == usergäst.Förnamn).Select(x => x.BokningId);


            var nyorder = new Order { Pris = _kostnad, GästId = usergäst.Id, Produkt="Hotellnätter" };
            await _context.Ordrar.AddAsync(nyorder);
            await _context.SaveChangesAsync();
            
            var nätter = (_BookTo - _BookFrom).TotalDays;

            //ViewBag.namn = user.Namn.ToString();
            ViewBag.från = _BookFrom;
            ViewBag.till = _BookTo;
            ViewBag.mail = user.Email;
            //ViewBag.rum = _Room.Namn.ToString();
            ViewBag.antalnätter = _nätter;
            ViewBag.antGäster = _NoOfMembers;
            ViewBag.kostnad1 = _kostnad;


            return View();

        }


        private bool BokningExists(int id)
        {
            return _context.Bokningar.Any(e => e.Id == id);
        }
    }
}
