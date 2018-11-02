using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class ReorderDetail
    {
        public Int32 ReorderDetailID { get; set; }
        public Int32 ReorderQuantity { get; set; }
        public Int32 Cost { get; set; }

        public Reorder Reorder { get; set; }
        public Book Book { get; set; }
    }
}
