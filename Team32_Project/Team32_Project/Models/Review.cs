using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Team32_Project.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }

        [DisplayFormat(DataFormatString="{0:#.#}")]
        [Display(Name = "Book Rating")]
        public Decimal Rating { get; set; }

        [Display(Name = "Customer Review")]
        public String CustomerReview { get; set; }

        public AppUser Author { get; set; }
        public AppUser Approver { get; set; }
        public Book Book { get; set; }
    }
}
