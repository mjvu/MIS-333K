using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Team32_Project.Models
{
    public class AppUser : IdentityUser
    {
        //Identity creates several of the important ones for you
        //Full documentation of the IdentityUser class can be found at
        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identityuser?view=aspnetcore-1.1&viewFallbackFrom=aspnetcore-2.1

        //TODO: Change this property because it is not proper
        public Int32 UserID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        public String Birthday { get; set; }
        public String SocialSecurity { get; set; }

        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        [Range(1, 5, ErrorMessage = "This is not a valid zip code.")]
        public String ZipCode { get; set; }

        public Boolean Active { get; set; }

        public List<Order> Orders { get; set; }

        [InverseProperty("Author")]
        public List<Review> ReviewsWritten { get; set; }
        [InverseProperty("Approver")]
        public List<Review> ReviewsApproved { get; set; }

        public List<Reorder> Reorders { get; set; }
        public List<Coupon> Coupons { get; set; }

        public AppUser()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            if (ReviewsWritten == null)
            {
                ReviewsWritten = new List<Review>();
            }

            if (ReviewsApproved == null)
            {
                ReviewsApproved = new List<Review>();
            }

            if (Reorders == null)
            {
                Reorders = new List<Reorder>();
            }

            if (Coupons == null)
            {
                Coupons = new List<Coupon>();
            }
        }
    }
}
