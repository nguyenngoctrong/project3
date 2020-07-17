using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class Password
    {
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }


    }
}