using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.FrameWork
{
    public class BillInfor
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Address")]
        public string Cus_Note { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression(@"(09|01|07[2|6|8|9])+([0-9]{7,9})\b", ErrorMessage = "Phone Number is invalid !")]
        public string Phone { get; set; }
        [DisplayName("Total Price")]
        public int totalPrice { get; set; }
    }
}
