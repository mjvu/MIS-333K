using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class Order
    {
        public Int32 OrderID { get; set; }

        [Display(Name = "Order Number")]
        public Int32 OrderNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public enum Status { Pending, Shipped }
        [Display(Name = "Order Status")]
        public Status OrderStatus { get; set; }

        [Display(Name = "Order Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderSubtotal
        {
            get { return OrderDetails.Sum(od => od.ExtendedPrice); }
        }

        [Display(Name = "Shipping Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal ShippingPrice { get; set; }

        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal
        {
            get { return OrderSubtotal + ShippingPrice; }
        }

        public AppUser Customer { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            if (OrderDetails == null)
            {
                OrderDetails = new List<OrderDetail>();
            }
        }
    }
}
