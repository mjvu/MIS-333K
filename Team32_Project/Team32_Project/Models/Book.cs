using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team32_Project.Models
{
    public class Book
    {
        public Int32 BookID { get; set; }
        public Int32 UniqueID { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }

        public String Description { get; set; }
        public Boolean Inactive { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.#}")]
        [Display(Name = "Average Rating")]
        public Decimal AverageRating { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        [Display(Name = "Reorder Point")]
        public Int32 ReorderPoint { get; set; }

        [Display(Name = "Copies on Hand")]
        public Int32 CopiesOnHand { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Last Ordered")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastOrdered { get; set; }

        public List<Review> Reviews { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ReorderDetail> ReorderDetails { get; set; }
        public Genre Genre { get; set; }

        public Book()
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>();
            }

            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }

            if (ReorderDetails == null)
            {
                ReorderDetails = new List<ReorderDetail>();
            }
        }
    }
}
