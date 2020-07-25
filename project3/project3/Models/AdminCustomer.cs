using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class AdminCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdminCustomer() { }

        public int Id_Cus { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Birth { get; set; }

        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}