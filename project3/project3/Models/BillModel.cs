using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class BillModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BillModel(){}

        public int Id_Bill { get; set; }
        public Nullable<int> Id_Cus { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
        public string Bill_Status { get; set; }
    }
}