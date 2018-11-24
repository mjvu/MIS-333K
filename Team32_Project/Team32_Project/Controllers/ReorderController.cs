using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team32_Project.DAL;
using Team32_Project.Models;

namespace Team32_Project.Controllers
{
    public class ReorderController : Controller
    {
        private readonly AppDbContext _context;

        public ReorderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Reorder
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reorders.ToListAsync());
        }

        // GET: Reorder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorder = await _context.Reorders
                .FirstOrDefaultAsync(m => m.ReorderID == id);
            if (reorder == null)
            {
                return NotFound();
            }

            return View(reorder);
        }

        // GET: Reorder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reorder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReorderID,ReorderType")] Reorder reorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reorder);
        }

        // GET: Reorder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorder = await _context.Reorders.FindAsync(id);
            if (reorder == null)
            {
                return NotFound();
            }
            return View(reorder);
        }

        // POST: Reorder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReorderID,ReorderType")] Reorder reorder)
        {
            if (id != reorder.ReorderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReorderExists(reorder.ReorderID))
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
            return View(reorder);
        }

        // GET: Reorder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorder = await _context.Reorders
                .FirstOrDefaultAsync(m => m.ReorderID == id);
            if (reorder == null)
            {
                return NotFound();
            }

            return View(reorder);
        }

        // POST: Reorder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reorder = await _context.Reorders.FindAsync(id);
            _context.Reorders.Remove(reorder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReorderExists(int id)
        {
            return _context.Reorders.Any(e => e.ReorderID == id);
        }
    }
}
