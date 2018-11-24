using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class Order
    {
        public Int32 OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public Boolean Status { get; set; }

        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Coupon> Coupons { get; set; }
    }
}
