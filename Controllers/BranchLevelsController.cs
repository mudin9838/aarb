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
    public class BranchLevelsController : Controller
    {
        private readonly OSContext _context;

        public BranchLevelsController(OSContext context)
        {
            _context = context;
        }

        // GET: BranchLevels
        public async Task<IActionResult> Index()
        {
            var oSContext = _context.BranchLevels.Include(b => b.BudgetYear);
            return View(await oSContext.ToListAsync());
        }

        // GET: BranchLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchLevel = await _context.BranchLevels
                .Include(b => b.BudgetYear)
                .FirstOrDefaultAsync(m => m.BranchLevelId == id);
            if (branchLevel == null)
            {
                return NotFound();
            }

            return View(branchLevel);
        }

        // GET: BranchLevels/Create
        public IActionResult Create()
        {
            ViewData["BudgetYearId"] = new SelectList(_context.AarevenueBureaus, "BudgetYearId", "AarevenueBureauNameAmharic");
            return View();
        }

        // POST: BranchLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchLevelId,BranchLevelNameAmh,BranchLevelNamEng,BudgetYearId")] BranchLevel branchLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BudgetYearId"] = new SelectList(_context.AarevenueBureaus, "BudgetYearId", "AarevenueBureauNameAmharic", branchLevel.BudgetYearId);
            return View(branchLevel);
        }

        // GET: BranchLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchLevel = await _context.BranchLevels.FindAsync(id);
            if (branchLevel == null)
            {
                return NotFound();
            }
            ViewData["BudgetYearId"] = new SelectList(_context.AarevenueBureaus, "BudgetYearId", "AarevenueBureauNameAmharic", branchLevel.BudgetYearId);
            return View(branchLevel);
        }

        // POST: BranchLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchLevelId,BranchLevelNameAmh,BranchLevelNamEng,BudgetYearId")] BranchLevel branchLevel)
        {
            if (id != branchLevel.BranchLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchLevelExists(branchLevel.BranchLevelId))
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
            ViewData["BudgetYearId"] = new SelectList(_context.AarevenueBureaus, "BudgetYearId", "AarevenueBureauNameAmharic", branchLevel.BudgetYearId);
            return View(branchLevel);
        }

        // GET: BranchLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchLevel = await _context.BranchLevels
                .Include(b => b.BudgetYear)
                .FirstOrDefaultAsync(m => m.BranchLevelId == id);
            if (branchLevel == null)
            {
                return NotFound();
            }

            return View(branchLevel);
        }

        // POST: BranchLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchLevel = await _context.BranchLevels.FindAsync(id);
            _context.BranchLevels.Remove(branchLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchLevelExists(int id)
        {
            return _context.BranchLevels.Any(e => e.BranchLevelId == id);
        }
    }
}
