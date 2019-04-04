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
    public class TaskController : Controller
    {
        private readonly MSRDbContext _context;

        public TaskController(MSRDbContext context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
            var mSRDbContext = _context.Tasks.Include(a => a.Employee).Include(a => a.Apps);
            return View(await mSRDbContext.ToListAsync());
            //return View(await _context.Tasks.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSRTask = await _context.Tasks
                .Include(a => a.Employee)
                .Include(a => a.Apps)
                .FirstOrDefaultAsync(m => m.MsrID == id);
            if (mSRTask == null)
            {
                return NotFound();
            }

            return View(mSRTask);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            ViewData["AssignedEmp"] = new SelectList(_context.Employees, "EmpID", "Fullname");
            ViewData["AssignedApp"] = new SelectList(_context.Apps, "AppID", "AppName");
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MsrID,AppTitle,MSRtitle,DateAdded,MSRNote,AssignedEmpID,AssignedAppID")] MSRTask mSRTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mSRTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedEmp"] = new SelectList(_context.Employees, "EmpID", "Fullname", mSRTask.AssignedEmpID);
            ViewData["AssignedApp"] = new SelectList(_context.Apps, "AppID", "AppName", mSRTask.AssignedAppID);
            return View(mSRTask);
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSRTask = await _context.Tasks.FindAsync(id);
            if (mSRTask == null)
            {
                return NotFound();
            }
            ViewData["AssignedEmp"] = new SelectList(_context.Employees, "EmpID", "Fullname", mSRTask.AssignedEmpID);
            ViewData["AssignedApp"] = new SelectList(_context.Apps, "AppID", "AppName", mSRTask.AssignedAppID);
            return View(mSRTask);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MsrID,AppTitle,MSRtitle,DateAdded,MSRNote,AssignedEmpID,AssignedAppID")] MSRTask mSRTask)
        {
            if (id != mSRTask.MsrID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mSRTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MSRTaskExists(mSRTask.MsrID))
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
            ViewData["AssignedEmp"] = new SelectList(_context.Analysts, "EmpID", "Fullname", mSRTask.AssignedEmpID);
            ViewData["AssignedApp"] = new SelectList(_context.Apps, "AppID", "AppName", mSRTask.AssignedAppID);
            return View(mSRTask);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mSRTask = await _context.Tasks
                .FirstOrDefaultAsync(m => m.MsrID == id);
            if (mSRTask == null)
            {
                return NotFound();
            }

            return View(mSRTask);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mSRTask = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(mSRTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MSRTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.MsrID == id);
        }
    }
}
