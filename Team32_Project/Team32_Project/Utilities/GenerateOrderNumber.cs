using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team32_Project.DAL;

namespace Team32_Project.Utilities
{
    public class GenerateOrderNumber
    {
        public static Int32 GetNextOrderNumber(AppDbContext db)
        {
            Int32 intMaxOrderNumber; //the current maximum order number
            Int32 intNextOrderNumber; //the order number for the next class

            if (db.Orders.Count() == 0) //there are no orders in the database yet
            {
                intMaxOrderNumber = 10000; //order numbers start at 10001
            }
            else
            {
                intMaxOrderNumber = db.Orders.Max(c => c.OrderNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextOrderNumber = intMaxOrderNumber + 1;

            //return the value
            return intNextOrderNumber;
        }
    }
}
