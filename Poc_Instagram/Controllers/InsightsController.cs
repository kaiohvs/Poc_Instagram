using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poc_Instagram.Data;
using Poc_Instagram.Models;

namespace Poc_Instagram.Controllers
{
    public class InsightsController : Controller
    {
        private readonly BdContext _context;

        public InsightsController(BdContext context)
        {
            _context = context;
        }

        // GET: Insights
        public async Task<IActionResult> Index()
        {
              return View(await _context.Insights.ToListAsync());
        }

        // GET: Insights/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Insights == null)
            {
                return NotFound();
            }

            var insight = await _context.Insights
                .FirstOrDefaultAsync(m => m.IdInsight == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // GET: Insights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInsight,Name")] Insight insight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insight);
        }

        // GET: Insights/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Insights == null)
            {
                return NotFound();
            }

            var insight = await _context.Insights.FindAsync(id);
            if (insight == null)
            {
                return NotFound();
            }
            return View(insight);
        }

        // POST: Insights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdInsight,Name")] Insight insight)
        {
            if (id != insight.IdInsight)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsightExists(insight.IdInsight))
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
            return View(insight);
        }

        // GET: Insights/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Insights == null)
            {
                return NotFound();
            }

            var insight = await _context.Insights
                .FirstOrDefaultAsync(m => m.IdInsight == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // POST: Insights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Insights == null)
            {
                return Problem("Entity set 'BdContext.Insights'  is null.");
            }
            var insight = await _context.Insights.FindAsync(id);
            if (insight != null)
            {
                _context.Insights.Remove(insight);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsightExists(long id)
        {
          return _context.Insights.Any(e => e.IdInsight == id);
        }
    }
}
