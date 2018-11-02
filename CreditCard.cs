using System;
namespace Team32_Project.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }
        public Int32 CreditCardNumber { get; set; }

        public User User { get; set; }
    }
}
