﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Donations.Data;
using Donations.Models;

namespace Donations.Controllers
{
    public class MoneyDonationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneyDonationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MoneyDonations
        public async Task<IActionResult> Index()
        {
            return View(await _context.MoneyDonation.ToListAsync());
        }

        // GET: MoneyDonations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonation == null)
            {
                return NotFound();
            }

            return View(moneyDonation);
        }

        // GET: MoneyDonations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MoneyDonations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Donor,CreatedAt,Used,Description")] MoneyDonation moneyDonation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moneyDonation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation.FindAsync(id);
            if (moneyDonation == null)
            {
                return NotFound();
            }
            return View(moneyDonation);
        }

        // POST: MoneyDonations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,Donor,CreatedAt,Used,Description")] MoneyDonation moneyDonation)
        {
            if (id != moneyDonation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moneyDonation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyDonationExists(moneyDonation.Id))
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
            return View(moneyDonation);
        }

        // GET: MoneyDonations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moneyDonation = await _context.MoneyDonation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moneyDonation == null)
            {
                return NotFound();
            }

            return View(moneyDonation);
        }

        // POST: MoneyDonations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moneyDonation = await _context.MoneyDonation.FindAsync(id);
            _context.MoneyDonation.Remove(moneyDonation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyDonationExists(int id)
        {
            return _context.MoneyDonation.Any(e => e.Id == id);
        }
    }
}
