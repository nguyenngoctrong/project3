using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.FrameWork;

namespace project3.Models
{
    public class Home
    {
        public List<Bouquest> bouquests { get; set; }
        public Customer customer { get; set; }
    }
}