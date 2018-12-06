using System;
using System.ComponentModel.DataAnnotations;

namespace Team32_Project.Models
{
    public class CreditCard
    {
        public Int32 CreditCardID { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [Display(Name = "Credit Card 1")]
        [Range(16, 16, ErrorMessage = "Credit Card has to have 16 digits.")]
        [DataType(DataType.CreditCard)]
        public String Card1 { get; set; }

        [Display(Name = "Credit Card 2")]
        [Range(16, 16, ErrorMessage = "Credit Card has to have 16 digits.")]
        [DataType(DataType.CreditCard)]
        public String Card2 { get; set; }

        [Display(Name = "Credit Card 3")]
        [Range(16, 16, ErrorMessage = "Credit Card has to have 16 digits.")]
        [DataType(DataType.CreditCard)]
        public String Card3 { get; set; }

        public AppUser Customer { get; set; }
    }
}
