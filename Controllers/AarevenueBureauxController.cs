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
    public class AarevenueBureauxController : Controller
    {
        private readonly OSContext _context;

        public AarevenueBureauxController(OSContext context)
        {
            _context = context;
        }

        // GET: AarevenueBureaux
        public async Task<IActionResult> Index()
        {
            var oSContext = _context.AarevenueBureaus.Include(a => a.BudgetYearNavigation);
            return View(await oSContext.ToListAsync());
        }

        // GET: AarevenueBureaux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aarevenueBureau = await _context.AarevenueBureaus
                .Include(a => a.BudgetYearNavigation)
                .FirstOrDefaultAsync(m => m.BudgetYearId == id);
            if (aarevenueBureau == null)
            {
                return NotFound();
            }

            return View(aarevenueBureau);
        }

        // GET: AarevenueBureaux/Create
        public IActionResult Create()
        {
            ViewData["BudgetYearId"] = new SelectList(_context.AafinanceBureaus, "BudgetYearId", "AafinanceBureaunNameAmharic");
            return View();
        }

        // POST: AarevenueBureaux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BudgetYearId,AarevenueBureauNameAmharic,AarevenueBureauNameEnglish,LetterNo,InsertedDate,UpdatedDate,DeletedDate,InsertedBy,UpdatedBy,DeletedBy,BudgetYear,ApprovedBudget")] AarevenueBureau aarevenueBureau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aarevenueBureau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetYearId"] = new SelectList(_context.AafinanceBureaus, "BudgetYearId", "AafinanceBureaunNameAmharic", aarevenueBureau.ApprovedBudget);
            return View(aarevenueBureau);
        }

        // GET: AarevenueBureaux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aarevenueBureau = await _context.AarevenueBureaus.FindAsync(id);
            if (aarevenueBureau == null)
            {
                return NotFound();
            }
            ViewData["BudgetYearId"] = new SelectList(_context.AafinanceBureaus, "BudgetYearId", "AafinanceBureaunNameAmharic", aarevenueBureau.BudgetYearId);
            return View(aarevenueBureau);
        }

        // POST: AarevenueBureaux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BudgetYearId,AarevenueBureauNameAmharic,AarevenueBureauNameEnglish,LetterNo,InsertedDate,UpdatedDate,DeletedDate,InsertedBy,UpdatedBy,DeletedBy,BudgetYear,ApprovedBudget")] AarevenueBureau aarevenueBureau)
        {
            if (id != aarevenueBureau.BudgetYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aarevenueBureau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AarevenueBureauExists(aarevenueBureau.BudgetYearId))
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
            ViewData["BudgetYearId"] = new SelectList(_context.AafinanceBureaus, "BudgetYearId", "AafinanceBureaunNameAmharic", aarevenueBureau.BudgetYearId);
            return View(aarevenueBureau);
        }

        // GET: AarevenueBureaux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aarevenueBureau = await _context.AarevenueBureaus
                .Include(a => a.BudgetYearNavigation)
                .FirstOrDefaultAsync(m => m.BudgetYearId == id);
            if (aarevenueBureau == null)
            {
                return NotFound();
            }

            return View(aarevenueBureau);
        }

        // POST: AarevenueBureaux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aarevenueBureau = await _context.AarevenueBureaus.FindAsync(id);
            _context.AarevenueBureaus.Remove(aarevenueBureau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AarevenueBureauExists(int id)
        {
            return _context.AarevenueBureaus.Any(e => e.BudgetYearId == id);
        }
    }
}
