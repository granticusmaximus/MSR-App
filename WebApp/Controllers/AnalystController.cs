using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AnalystController : Controller
    {
        private readonly MSRDbContext _context;

        public AnalystController(MSRDbContext context)
        {
            _context = context;
        }

        // GET: Analyst
        public async Task<IActionResult> Index()
        {
            return View(await _context.Analysts.ToListAsync());
        }

        // GET: Analyst/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyst = await _context.Analysts
                .FirstOrDefaultAsync(m => m.BAID == id);
            if (analyst == null)
            {
                return NotFound();
            }

            return View(analyst);
        }

        // GET: Analyst/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Analyst/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BAID,BAFName,BALName,Email,Phone")] Analyst analyst)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analyst);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(analyst);
        }

        // GET: Analyst/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyst = await _context.Analysts.FindAsync(id);
            if (analyst == null)
            {
                return NotFound();
            }
            return View(analyst);
        }

        // POST: Analyst/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BAID,BAFName,BALName,Email,Phone")] Analyst analyst)
        {
            if (id != analyst.BAID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analyst);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalystExists(analyst.BAID))
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
            return View(analyst);
        }

        // GET: Analyst/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analyst = await _context.Analysts
                .FirstOrDefaultAsync(m => m.BAID == id);
            if (analyst == null)
            {
                return NotFound();
            }

            return View(analyst);
        }

        // POST: Analyst/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var analyst = await _context.Analysts.FindAsync(id);
            _context.Analysts.Remove(analyst);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalystExists(int id)
        {
            return _context.Analysts.Any(e => e.BAID == id);
        }
    }
}
