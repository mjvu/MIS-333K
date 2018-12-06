using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class ReorderDetail
    {
        public Int32 ReorderDetailID { get; set; }
        public Decimal ReorderQuantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Cost { get; set; }

        public Reorder Reorder { get; set; }
        public Book Book { get; set; }
    }
}
