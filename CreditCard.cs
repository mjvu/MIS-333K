using System;
namespace Project.Properties
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }
        public Int32 CreditCardNumber { get; set; }

        public User Users { get; set; }
    }
}
