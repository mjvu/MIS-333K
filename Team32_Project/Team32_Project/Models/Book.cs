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
        //public Boolean Genre { get; set; }
        public Decimal Cost { get; set; }
        public Int32 ReorderPoint { get; set; }
        public Int32 Rating { get; set; }


        //TODO: When doing migration - Unable to determine the relationship 
        //represented by navigation property 'Book.Reviews' of type 
        //'List<Review>'. Either manually configure the relationship, 
        //or ignore this property using the '[NotMapped]' attribute or 
        //by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
        public List<Review> Reviews { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ReorderDetail> ReorderDetails { get; set; }
        public Genre Genre { get; set; }
    }
}