using System;
using System.Collections.Generic;

namespace Team32_Project.Models
{
    public class Book
    {
        public Int32 BookID { get; set; }
        public Int32 UniqueID { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public Decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public String Description { get; set; }
        public Int32 Quantity { get; set; }
        public Boolean Active { get; set; }
        public Decimal Cost { get; set; }
        public Decimal ReorderPoint { get; set; }
        public Decimal Rating { get; set; }
        public Decimal CopiesOnHand { get; set; }
        public DateTime LastOrdered { get; set; }

        public List<Review> Reviews { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ReorderDetail> ReorderDetails { get; set; }
        public Genre Genre { get; set; }
    }
}
