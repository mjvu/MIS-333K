using System;
using System.Collections.Generic;

namespace Team32_Project.Models
{
    public class User
    {
        public Int32 UserID { get; set; }
        public Boolean Role { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public Int32 ZipCode { get; set; }
        public Int32 PhoneNumber { get; set; }
        public Boolean Active { get; set; }


        public List<Order> Orders { get; set; }
        public List<Review> ReviewsWritten { get; set; }
        public List<Review> ReviewsApproved { get; set; }
        public List<Reorder> Reorders { get; set; }
        public List<Coupon> Coupons { get; set; }
    }
}
