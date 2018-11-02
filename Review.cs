using System;
namespace Project.Properties
{
    public class Review
    {
        public Int32 ReviewID { get; set; }
        public Int32 Rating { get; set; }
        public String Review { get; set; }
        public String Author { get; set; }
        public String Approver { get; set; }

        public List<Book> Books { get; set; }
    }
}
