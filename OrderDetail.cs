using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Price { get; set; }

        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
