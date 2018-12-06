using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team32_Project.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }

        [DisplayFormat(DataFormatString="{0:#.#}")]
        public Decimal Rating { get; set; }
        public String CustomerReview { get; set; }

        public AppUser Author { get; set; }
        public AppUser Approver { get; set; }

        public Book Book { get; set; }
    }
}
