using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team32_Project.DAL;

namespace Team32_Project.Utilities
{
    public class GenerateBookNumber
    {
        public static Int32 GetNextBookNumber(AppDbContext db)
        {
            Int32 intMaxBookNumber; //the current maximum book number
            Int32 intNextBookNumber; //the book number for the next book

            if (db.Books.Count() == 300) //there are 300 books in the database
            {
                intMaxBookNumber = 789300; //book numbers start at 789301
            }
            else
            {
                intMaxBookNumber = db.Books.Max(b => b.UniqueID); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextBookNumber = intMaxBookNumber + 1;

            //return the value
            return intNextBookNumber;
        }
    }
}
