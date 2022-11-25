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
    public class AllocateMoneysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllocateMoneysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllocateMoneys
        public async Task<IActionResult> Index()
        {
            double collectedAmount = 0;
            double allocatedAmount = 0;

            foreach (var item in await _context.MoneyDonation.ToListAsync())
            {
                collectedAmount += item.Amount;
            }
            foreach (var item in await _context.AllocateMoney.ToListAsync())
            {
                allocatedAmount += item.Amount;
            }

            ViewData["RemainAmount"] = String.Format("{0:C}", collectedAmount - allocatedAmount);
            ViewData["AllocatedAmount"] = String.Format("{0:C}", allocatedAmount);
            ViewData["DonatedMoney"] = String.Format("{0:C}", collectedAmount);

            return View(await _context.AllocateMoney.ToListAsync());
        }

        public JsonResult GetData()
        {

            List<AllocateGoods> allocateToDisasters = new();
            var disasterList = _context.AllocateGoods.ToList();

            foreach (var item in disasterList)
            {
                allocateToDisasters.Add(item);
            }

            return Json(disasterList);
        }

        // GET: AllocateMoneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocateMoney == null)
            {
                return NotFound();
            }

            return View(allocateMoney);
        }

        // GET: AllocateMoneys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllocateMoneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,AllocatedTo,Description")] AllocateMoney allocateMoney)
        {
            if (ModelState.IsValid)
            {
                double remainAmount = 0;
                var items = await _context.MoneyDonation.ToListAsync();
                foreach (var item in items)
                {
                    remainAmount += item.Amount;
                }

                AllocateMoney allocateMoney1 = new() { Amount = allocateMoney.Amount, Description = allocateMoney.Description, AllocatedTo = allocateMoney.AllocatedTo};
                _context.Add(allocateMoney1);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(allocateMoney);
        }

        // GET: AllocateMoneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney.FindAsync(id);
            if (allocateMoney == null)
            {
                return NotFound();
            }
            return View(allocateMoney);
        }

        // POST: AllocateMoneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,RemainingAmount,AllocatedTo,Description")] AllocateMoney allocateMoney)
        {
            if (id != allocateMoney.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocateMoney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateMoneyExists(allocateMoney.Id))
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
            return View(allocateMoney);
        }

        // GET: AllocateMoneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateMoney = await _context.AllocateMoney
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocateMoney == null)
            {
                return NotFound();
            }

            return View(allocateMoney);
        }

        // POST: AllocateMoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocateMoney = await _context.AllocateMoney.FindAsync(id);
            _context.AllocateMoney.Remove(allocateMoney);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateMoneyExists(int id)
        {
            return _context.AllocateMoney.Any(e => e.Id == id);
        }
    }
}
