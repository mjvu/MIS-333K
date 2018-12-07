using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team32_Project.DAL;
using Team32_Project.Models;

namespace Team32_Project.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public OrderDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrderDetails/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _context.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderDetail orderDetail)
        {
            //Find the related order detail in the database
            OrderDetail DbOrderDetail = _context.OrderDetails
                                        .Include(o => o.Book)
                                        .Include(o => o.Order)
                                        .FirstOrDefault(o => o.OrderDetailID ==
                                                            orderDetail.OrderDetailID);

            //update the related fields
            DbOrderDetail.Quantity = orderDetail.Quantity;
            DbOrderDetail.BookPrice = DbOrderDetail.Book.Price;
            DbOrderDetail.ExtendedPrice = DbOrderDetail.BookPrice * DbOrderDetail.Quantity;

            //update the database
            if (ModelState.IsValid)
            {
                _context.OrderDetails.Update(DbOrderDetail);
                _context.SaveChanges();
                return RedirectToAction("Details", "Orders", new { id = DbOrderDetail.Order.OrderID });
            }

            return View(orderDetail);
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = await _context.OrderDetails
                .FirstOrDefaultAsync(m => m.OrderDetailID == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Find the related order detail in the database
            OrderDetail DbOrderDetail = _context.OrderDetails
                                        .Include(o => o.Book)
                                        .Include(o => o.Order)
                                        .FirstOrDefault(o => o.OrderDetailID == id);
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Orders", new { id = DbOrderDetail.Order.OrderID });
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailID == id);
        }
    }
}
