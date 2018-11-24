using System;
using System.Collections.Generic;

namespace Team32_Project.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }
        public Int32 Rating { get; set; }
        public String CustomerReview { get; set; }
        public String Author { get; set; }
        public String Approver { get; set; }

        public Book Book { get; set; }
    }
}
