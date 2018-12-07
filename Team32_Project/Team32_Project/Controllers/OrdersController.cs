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
using Team32_Project.Utilities;

namespace Team32_Project.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public IActionResult Index()
        {
            List<Order> Orders = new List<Order>();
            if (User.IsInRole("Customer"))
            {
                Orders = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name).Include(o => o.OrderDetails).OrderByDescending(o => o.OrderDate).ToList();
            }
            else //user is manager and can see all orders
            {
                Orders = _context.Orders.Include(o => o.OrderDetails).ToList();
            }
            return View(Orders);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "Specify an order to view!" });
            }

            Order order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails).ThenInclude(o => o.Book)
                .FirstOrDefault(o => o.OrderID == id);

            order.ShippingPrice = CalculateShippingPrice.GetTotalShippingPrice(order);

            //make sure a customer isn't trying to look at someone else's order
            if (User.IsInRole("Manager") == false && order.Customer.UserName != User.Identity.Name)
            {
                return View("Error", new string[] { "You are not authorized to view this order!" });
            }

            if (order == null)
            {
                return View("Error", new string[] { "Order was not found" });
            }
            return View(order);
        }


        // GET: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        public IActionResult Create(Order cart)
        {
            //check if there is a pending order
            Order FindCart = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name).
                FirstOrDefault(o => o.OrderStatus == Order.Status.Pending);

            //if there is no pending order, create one
            if (FindCart == null)
            {
                cart.OrderNumber = GenerateOrderNumber.GetNextOrderNumber(_context);
                cart.OrderDate = System.DateTime.Today;
                cart.OrderStatus = Order.Status.Pending;
                //find customer associated with order
                String Userid = User.Identity.Name;
                AppUser customer = _context.Users.FirstOrDefault(u => u.UserName == Userid);
                cart.Customer = customer;

                if (ModelState.IsValid)
                {
                    _context.Orders.Add(cart);
                    _context.SaveChanges();
                    return RedirectToAction("Details", new { id = cart.OrderID });
                }
            }
            //if there is a pending order, go to it
            else
            {
                //find the order based on the order id
                Order order = _context.Orders.Find(FindCart.OrderID);

                return RedirectToAction("Details", new { id = order.OrderID });
            }
            return View(FindCart);
        }

        [Authorize(Roles = "Customer")]
        //GET: Orders/AddToOrder
        //creates order details for an order
        public IActionResult AddToOrder(int? id, int? OrderID)
        {
            //find cart
            Order FindCart = _context.Orders.Where(o => o.Customer.UserName == User.Identity.Name).
                FirstOrDefault(o => o.OrderStatus == Order.Status.Pending);

            if (FindCart == null)
            {
                return RedirectToAction("Create");
            }
            Order cart = _context.Orders.Find(FindCart.OrderID);
            OrderID = cart.OrderID;
            if (id == null)
            {
                return View("Error", new string[] { "You must specify a book to add!" });
            }
            if (OrderID == null)
            {
                return View("Error", new string[] { "You must specify an order to add to!" });
            }
            Order order = _context.Orders.Find(OrderID);
            Book book = _context.Books.Find(id);
            if (order == null)
            {
                return View("Error", new string[] { "Order not found!" });
            }
            if (book == null)
            {
                return View("Error", new string[] { "Book not found!" });
            }

            //book is not in stock
            if (book.CopiesOnHand == 0)
            {
                return View("Error", new string[] { "Book is not in stock!" });
            }

            OrderDetail od = new OrderDetail() { Order = order, Book = book };

            return View("AddToOrder", od);
        }

        [Authorize(Roles = "Customer")]
        //POST: Orders/AddToOrder
        [HttpPost]
        public IActionResult AddToOrder(OrderDetail od)
        {
            //find the book associated with the selected book id
            Book book = _context.Books.Find(od.Book.BookID);

            //set the order detail's product equal to the product we just found
            od.Book = book;

            //find the order based on the order id
            Order order = _context.Orders.Find(od.Order.OrderID);

            //set the order detail's order equal to the order we just found
            od.Order = order;

            //set the product price for this detail equal to the current product price
            od.BookPrice = od.Book.Price;

            //calculate the shipping price

            if (od.Quantity > book.CopiesOnHand)
            {
                return View("Error", new string[] { "You cannot add a quantity greater than the number of books in stock!" });
            }

            //calculate product price
            od.ExtendedPrice = od.Quantity * od.BookPrice;

            if (ModelState.IsValid)
            {
                _context.OrderDetails.Add(od);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = od.Order.OrderID });
            }
            return View(od);
        }


        // GET: Orders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                                .Include(o => o.OrderDetails)
                                    .ThenInclude(o => o.Book)
                                .FirstOrDefault(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Order order)
        {
            //Find the related order in the database
            Order DbOrder = _context.Orders.Find(order.OrderID);

            //update the related fields
            DbOrder.OrderStatus = order.OrderStatus;

            //Update the database
            _context.Orders.Update(DbOrder);

            //Save changes
            _context.SaveChanges();

            //Go back to index
            return RedirectToAction(nameof(Index));
        }

        //GET: Orders/RemoveFromOrder
        public IActionResult RemoveFromOrder(int? id)
        {
            if (id == null)
            {
                return View("Error", new string[] { "You need to specify an order id" });
            }

            Order order = _context.Orders.Include(o => o.OrderDetails)
                                            .ThenInclude(o => o.Book)
                                         .FirstOrDefault(o => o.OrderID == id);

            if (order == null || order.OrderDetails.Count == 0)//order is not found
            {
                return RedirectToAction("Details", new { id = id });
            }

            //pass the list of order details to the view
            return View(order.OrderDetails);
        }

        // GET: Orders/Checkout/5
        public IActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                                .Include(o => o.OrderDetails)
                                    .ThenInclude(o => o.Book)
                                .FirstOrDefault(o => o.OrderID == id);
            //check if cart is empty
            Int32 CheckOrder = order.OrderDetails.Count();

            if (CheckOrder == 0)
            {
                return View("Error", new string[] { "You can't checkout an empty cart!" });
            }

            if (order == null)
            {
                return NotFound();
            }
            ViewBag.AllCards = GetAllCards();
            return View(order);
        }

        // POST: Orders/Checkout/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            //Find the related order in the database
            Order DbOrder = _context.Orders.Find(order.OrderID);

            ViewBag.AllCards = GetAllCards();
            
            //Update the database
            _context.Orders.Update(DbOrder);

            //Save changes
            _context.SaveChanges();

            //Go to confirmation page
            return RedirectToAction("OrderConfirmation");
        }

        public MultiSelectList GetAllCards()
        {
            List<CreditCard> allCards = _context.CreditCards.ToList();
            MultiSelectList cardList = new MultiSelectList(allCards, "CreditCardID", "CardNumber");
            return cardList;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
