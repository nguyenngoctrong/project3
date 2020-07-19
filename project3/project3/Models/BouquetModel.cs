using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.Models
{
    public class BouquetModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BouquetModel() { }

        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}