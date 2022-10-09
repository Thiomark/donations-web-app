using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Donation.Data;
using Donation.Models;

namespace Donation.Controllers
{
    public class GoodsDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsDonations
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoodsDonation.ToListAsync());
        }

        // GET: GoodsDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // GET: GoodsDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UpdatedAt,NumberOfItems,Category,Description,Donor,RemainingItems")] GoodsDonation goodsDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation.FindAsync(id);
            if (goodsDonation == null)
            {
                return NotFound();
            }
            return View(goodsDonation);
        }

        // POST: GoodsDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UpdatedAt,NumberOfItems,Category,Description,Donor,RemainingItems")] GoodsDonation goodsDonation)
        {
            if (id != goodsDonation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsDonationExists(goodsDonation.Id))
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
            return View(goodsDonation);
        }

        // GET: GoodsDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goodsDonation = await _context.GoodsDonation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goodsDonation == null)
            {
                return NotFound();
            }

            return View(goodsDonation);
        }

        // POST: GoodsDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goodsDonation = await _context.GoodsDonation.FindAsync(id);
            _context.GoodsDonation.Remove(goodsDonation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsDonationExists(int id)
        {
            return _context.GoodsDonation.Any(e => e.Id == id);
        }
    }
}
