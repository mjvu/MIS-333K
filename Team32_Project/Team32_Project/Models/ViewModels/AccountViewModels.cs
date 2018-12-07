﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Team32_Project.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class EditAccountInfoViewModel
    {
        public AppUser User { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        public String MiddleInitial { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required.")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required.")]
        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }   

    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String MiddleInitial { get; set; }
        public String LastName { get; set; }
        public String StreetAddress { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String ZipCode { get; set; }
        public String PhoneNumber { get; set; }
        public String UserName { get; set; }
        public String UserID { get; set; }
    }
}
