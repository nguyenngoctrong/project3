using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class EmailInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}