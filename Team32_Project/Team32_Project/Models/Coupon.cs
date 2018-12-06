using System;
using System.ComponentModel.DataAnnotations;

namespace Team32_Project.Models
{
    public class Coupon
    {
        public Int32 CouponID { get; set; }
        [Display(Name = "Coupon Code")]
        public Int32 CouponCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}")]
        [Display(Name = "XX% Off Your Order")]
        public Decimal CouponPercent { get; set; }

        [Display(Name = "Free Shipping Over $XX Amount")]
        public Decimal MinimumAccount { get; set; }
        [Display(Name = "Coupon Type")]
        public Boolean CouponType { get; set; }
        public String Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
