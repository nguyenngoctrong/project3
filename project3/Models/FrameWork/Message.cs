namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        public int Id_Mess { get; set; }

        public int Id_Bill { get; set; }

        [StringLength(20)]
        public string Sender { get; set; }

        [Column("Message")]
        [StringLength(100)]
        public string Message1 { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
