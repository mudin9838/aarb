using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aarb.Data;
using aarb.Models;

namespace aarb.Controllers
{
    public class AafinanceBureauxController : Controller
    {
        private readonly OSContext _context;

        public AafinanceBureauxController(OSContext context)
        {
            _context = context;
        }

        // GET: AafinanceBureaux
        public async Task<IActionResult> Index()
        {
            return View(await _context.AafinanceBureaus.ToListAsync());
        }

        // GET: AafinanceBureaux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aafinanceBureau = await _context.AafinanceBureaus
                .FirstOrDefaultAsync(m => m.BudgetYearId == id);
            if (aafinanceBureau == null)
            {
                return NotFound();
            }

            return View(aafinanceBureau);
        }

        // GET: AafinanceBureaux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AafinanceBureaux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetYearId,AafinanceBureaunNameAmharic,AafinanceBureaunNameEnglish,BudgetYear,ApprovedBudget,UplodedLetter")] AafinanceBureau aafinanceBureau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aafinanceBureau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aafinanceBureau);
        }

        // GET: AafinanceBureaux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aafinanceBureau = await _context.AafinanceBureaus.FindAsync(id);
            if (aafinanceBureau == null)
            {
                return NotFound();
            }
            return View(aafinanceBureau);
        }

        // POST: AafinanceBureaux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BudgetYearId,AafinanceBureaunNameAmharic,AafinanceBureaunNameEnglish,BudgetYear,ApprovedBudget,UplodedLetter")] AafinanceBureau aafinanceBureau)
        {
            if (id != aafinanceBureau.BudgetYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aafinanceBureau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AafinanceBureauExists(aafinanceBureau.BudgetYearId))
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
            return View(aafinanceBureau);
        }

        // GET: AafinanceBureaux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aafinanceBureau = await _context.AafinanceBureaus
                .FirstOrDefaultAsync(m => m.BudgetYearId == id);
            if (aafinanceBureau == null)
            {
                return NotFound();
            }

            return View(aafinanceBureau);
        }

        // POST: AafinanceBureaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aafinanceBureau = await _context.AafinanceBureaus.FindAsync(id);
            _context.AafinanceBureaus.Remove(aafinanceBureau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AafinanceBureauExists(int id)
        {
            return _context.AafinanceBureaus.Any(e => e.BudgetYearId == id);
        }
    }
}
