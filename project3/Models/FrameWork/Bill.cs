namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            Credits = new HashSet<Credit>();
            Messages = new HashSet<Message>();
        }

        [Key]
        public int Id_Bill { get; set; }

        public int? Id_Bou { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int? Id_Cus { get; set; }

        public int? Volume { get; set; }

        public DateTime? Order_Date { get; set; }

        public DateTime? Delivery_Date { get; set; }

        [StringLength(100)]
        public string Cus_Note { get; set; }

        [StringLength(20)]
        public string Bill_Status { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Credit> Credits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
