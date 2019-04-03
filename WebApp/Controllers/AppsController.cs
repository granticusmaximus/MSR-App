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
    public class AppsController : Controller
    {
        private readonly MSRDbContext _context;

        public AppsController(MSRDbContext context)
        {
            _context = context;
        }

        // GET: Apps
        public async Task<IActionResult> Index()
        {
            var mSRDbContext = _context.Apps.Include(a => a.Analyst).Include(a => a.Developer);
            return View(await mSRDbContext.ToListAsync());
        }

        // GET: Apps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appList = await _context.Apps
                .Include(a => a.Analyst)
                .Include(a => a.Developer)
                .FirstOrDefaultAsync(m => m.AppID == id);
            if (appList == null)
            {
                return NotFound();
            }

            return View(appList);
        }

        // GET: Apps/Create
        public IActionResult Create()
        {
            ViewData["AssignedBA"] = new SelectList(_context.Analysts, "BAID", "BAFullname");
            ViewData["AssignedDev"] = new SelectList(_context.Developers, "DevID", "DevFullname");
            return View();
        }

        // POST: Apps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppID,AppName,AppNotes,AssignedBA,AssignedDev")] AppList appList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedBA"] = new SelectList(_context.Analysts, "BAID", "BAFullname", appList.AssignedBA);
            ViewData["AssignedDev"] = new SelectList(_context.Developers, "DevID", "DevFullname", appList.AssignedDev);
            return View(appList);
        }

        // GET: Apps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appList = await _context.Apps.FindAsync(id);
            if (appList == null)
            {
                return NotFound();
            }
            ViewData["AssignedBA"] = new SelectList(_context.Analysts, "BAID", "BAID", appList.AssignedBA);
            ViewData["AssignedDev"] = new SelectList(_context.Developers, "DevID", "DevID", appList.AssignedDev);
            return View(appList);
        }

        // POST: Apps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppID,AppName,AppNotes,AssignedBA,AssignedDev")] AppList appList)
        {
            if (id != appList.AppID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppListExists(appList.AppID))
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
            ViewData["AssignedBA"] = new SelectList(_context.Analysts, "BAID", "BAID", appList.AssignedBA);
            ViewData["AssignedDev"] = new SelectList(_context.Developers, "DevID", "DevID", appList.AssignedDev);
            return View(appList);
        }

        // GET: Apps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appList = await _context.Apps
                .Include(a => a.Analyst)
                .Include(a => a.Developer)
                .FirstOrDefaultAsync(m => m.AppID == id);
            if (appList == null)
            {
                return NotFound();
            }

            return View(appList);
        }

        // POST: Apps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appList = await _context.Apps.FindAsync(id);
            _context.Apps.Remove(appList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppListExists(int id)
        {
            return _context.Apps.Any(e => e.AppID == id);
        }
    }
}
