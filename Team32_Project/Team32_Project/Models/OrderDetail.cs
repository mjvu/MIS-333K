using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Display(Name = "Quantity")]
        [Range(1, 99999999, ErrorMessage = "Quantity cannot be negative")]
        public Int32 Quantity { get; set; }

        [Display(Name = "Book Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal BookPrice { get; set; }

        [Display(Name = "Extended Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ExtendedPrice { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
