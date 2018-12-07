using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Team32_Project.Models
{
    public class CreditCard
    {
        [Display(Name = "Credit Card")]
        public Int32 CreditCardID { get; set; }

        [Required(ErrorMessage = "Credit card type is required.")]
        [Display(Name = "Credit Card Type")]
        public String CardType { get; set; }

        [Required(ErrorMessage = "Credit card number is required.")]
        [Display(Name = "Credit Card Number")]
        [Range(16, 16, ErrorMessage = "Credit Card has to have 16 digits.")]
        public String CardNumber { get; set; }

        public AppUser Customer { get; set; }
    }
}
