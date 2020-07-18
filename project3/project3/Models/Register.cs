using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public int Id_Role { get; set; }

    }
}