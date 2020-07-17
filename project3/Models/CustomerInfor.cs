using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class CustomerInfor
    {
        [ReadOnly(true)]
        public string Email { get; set; }

        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Uppercase first word")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Uppercase first word")]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression(@"/(09|01|07[2|6|8|9])+([0-9]{7,9})\b/g", ErrorMessage = "Phone Number is invalid !")]
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Birth { get; set; }

        [ReadOnly(true)]
        public string Role { get; set; }
    }
}