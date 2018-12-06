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
    public class ReorderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public ReorderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ReorderDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reorderDetail = _context.ReorderDetails.Find(id);
            if (reorderDetail == null)
            {
                return NotFound();
            }
            return View(reorderDetail);
        }

        // POST: ReorderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ReorderDetail reorderDetail)
        {
            //Find the related reorder detail in the database
            ReorderDetail DbReorderDetail = _context.ReorderDetails
                                        .Include(r => r.Book)
                                        .Include(r => r.Reorder)
                                        .FirstOrDefault(r => r.ReorderDetailID ==
                                                            reorderDetail.ReorderDetailID);

            //update the related fields
            DbReorderDetail.ReorderQuantity = reorderDetail.ReorderQuantity;
            DbReorderDetail.Cost = DbReorderDetail.Book.Cost;

            //update the database
            if (ModelState.IsValid)
            {
                _context.ReorderDetails.Update(DbReorderDetail);
                _context.SaveChanges();
                return RedirectToAction("Details", "Reorders", new { id = DbReorderDetail.Reorder.ReorderID });
            }

            return View(reorderDetail);
        }

        // GET: ReorderDetails/Delete/5
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

        // POST: ReorderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Find the related order detail in the database
            ReorderDetail DbReorderDetail = _context.ReorderDetails
                                        .Include(r => r.Book)
                                        .Include(r => r.Reorder)
                                        .FirstOrDefault(r => r.ReorderDetailID == id);
            var reorderDetail = await _context.ReorderDetails.FindAsync(id);
            _context.ReorderDetails.Remove(reorderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Reorders", new { id = DbReorderDetail.Reorder.ReorderID });
        }

        private bool ReorderDetailExists(int id)
        {
            return _context.ReorderDetails.Any(e => e.ReorderDetailID == id);
        }
    }
}
