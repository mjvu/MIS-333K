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

        public enum Status { Pending, Approved, Rejected }
        [Display(Name = "Review Status")]
        public String ReviewStatus { get; set; }

        [Display(Name = "Review By")]
        public AppUser Author { get; set; }

        [Display(Name = "Review Approved By")]
        public AppUser Approver { get; set; }

        [Display(Name = "Book Title")]
        public Book Book { get; set; }
    }
}
