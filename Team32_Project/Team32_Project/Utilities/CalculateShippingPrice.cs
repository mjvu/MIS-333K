using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team32_Project.DAL;
using Team32_Project.Models;

namespace Team32_Project.Utilities
{
    public class CalculateShippingPrice
    {
        public static Decimal GetTotalShippingPrice(Order order)
        {
            Decimal NumberofBooks = order.OrderDetails.Count();
            Decimal ShipPrice1;
            Decimal ShipPrice2;
            Decimal TotalShippingPrice;

            ShipPrice1 = 3.50m;
            ShipPrice2 = 1.50m;

            TotalShippingPrice = (1 * ShipPrice1) + ((NumberofBooks - 1) * ShipPrice2);

            return TotalShippingPrice;
        }
    }
}
