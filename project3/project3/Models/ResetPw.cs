using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Admination.Models
{
    public class ResetPw
    {
        [Required]
        public string Email { get; set; }
    }
}