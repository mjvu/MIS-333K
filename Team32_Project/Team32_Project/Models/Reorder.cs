using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class Reorder
    {
        public Int32 ReorderID { get; set; }
        public Boolean ReorderType { get; set; }

        public List<ReorderDetail> ReorderDetails { get; set; }

        public Reorder()
        {
            if (ReorderDetails == null)
            {
                ReorderDetails = new List<ReorderDetail>();
            }
        }
    }
}
