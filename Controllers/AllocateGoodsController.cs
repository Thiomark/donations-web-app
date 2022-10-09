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
    public class AllocateGoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllocateGoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AllocateGoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.AllocateGoods.ToListAsync());
        }

        public JsonResult GetDisastersData()
        {

            List<Disaster> disasters = new();
            var disasterList = _context.Disaster.ToList();

            foreach (var item in disasterList)
            {
                disasters.Add(item);
            }

            return Json(disasterList);
        }

        public JsonResult GetGoodsData()
        {

            List<GoodsDonation> donatedGoods = new();
            var goodsList = _context.GoodsDonation.ToList();

            foreach (var item in goodsList)
            {
                donatedGoods.Add(item);
            }

            return Json(goodsList);
        }

        // GET: AllocateGoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateGoods = await _context.AllocateGoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocateGoods == null)
            {
                return NotFound();
            }

            return View(allocateGoods);
        }

        // GET: AllocateGoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllocateGoods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Goods,AllocatedTo,Description")] AllocateGoods allocateGoods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocateGoods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allocateGoods);
        }

        // GET: AllocateGoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateGoods = await _context.AllocateGoods.FindAsync(id);
            if (allocateGoods == null)
            {
                return NotFound();
            }
            return View(allocateGoods);
        }

        // POST: AllocateGoods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Goods,AllocatedTo,Description")] AllocateGoods allocateGoods)
        {
            if (id != allocateGoods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocateGoods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocateGoodsExists(allocateGoods.Id))
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
            return View(allocateGoods);
        }

        // GET: AllocateGoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocateGoods = await _context.AllocateGoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocateGoods == null)
            {
                return NotFound();
            }

            return View(allocateGoods);
        }

        // POST: AllocateGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocateGoods = await _context.AllocateGoods.FindAsync(id);
            _context.AllocateGoods.Remove(allocateGoods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocateGoodsExists(int id)
        {
            return _context.AllocateGoods.Any(e => e.Id == id);
        }
    }
}
