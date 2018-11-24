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
    public class ReorderDetailController : Controller
    {
        private readonly AppDbContext _context;

        public ReorderDetailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReorderDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReorderDetails.ToListAsync());
        }

        // GET: ReorderDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorderDetail = await _context.ReorderDetails
                .FirstOrDefaultAsync(m => m.ReorderDetailID == id);
            if (reorderDetail == null)
            {
                return NotFound();
            }

            return View(reorderDetail);
        }

        // GET: ReorderDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReorderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReorderDetailID,ReorderQuantity,Cost")] ReorderDetail reorderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reorderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reorderDetail);
        }

        // GET: ReorderDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorderDetail = await _context.ReorderDetails.FindAsync(id);
            if (reorderDetail == null)
            {
                return NotFound();
            }
            return View(reorderDetail);
        }

        // POST: ReorderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReorderDetailID,ReorderQuantity,Cost")] ReorderDetail reorderDetail)
        {
            if (id != reorderDetail.ReorderDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reorderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReorderDetailExists(reorderDetail.ReorderDetailID))
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
            return View(reorderDetail);
        }

        // GET: ReorderDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorderDetail = await _context.ReorderDetails
                .FirstOrDefaultAsync(m => m.ReorderDetailID == id);
            if (reorderDetail == null)
            {
                return NotFound();
            }

            return View(reorderDetail);
        }

        // POST: ReorderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reorderDetail = await _context.ReorderDetails.FindAsync(id);
            _context.ReorderDetails.Remove(reorderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReorderDetailExists(int id)
        {
            return _context.ReorderDetails.Any(e => e.ReorderDetailID == id);
        }
    }
}
