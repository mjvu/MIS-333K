using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class Reorder
    {
        public Int32 ReorderID { get; set; }

        public enum Type { Manual, Automatic }
        [Display(Name = "Reorder Type")]
        public Type ReorderType { get; set; }

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
