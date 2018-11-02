using System;
namespace Project.Properties
{
    public class Coupon
    {
        public Int32 CouponID { get; set; }
        public Int32 CouponCode { get; set; }
        public Decimal CouponPercent { get; set; }
        public Boolean CouponType { get; set; }
        public String Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Order Orders { get; set; }
    }
}
