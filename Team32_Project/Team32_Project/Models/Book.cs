using System;
using System.Collections.Generic;

namespace Team32_Project.Models
{
    public class Book
    {
        public Int32 BookID { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public Decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public String Description { get; set; }
        public Int32 Quantity { get; set; }
        public Boolean Active { get; set; }
        public Boolean Genre { get; set; }
        public Decimal Cost { get; set; }
        public Int32 ReorderPoint { get; set; }
        public Int32 Rating { get; set; }

        public List<Review> Reviews { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ReorderDetail> ReorderDetails { get; set; }
        public List<Genre> Genres { get; set; }
    }
}