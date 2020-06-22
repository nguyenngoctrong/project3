namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credit")]
    public partial class Credit
    {
        public int Id { get; set; }

        public int? Id_Bill { get; set; }

        [StringLength(15)]
        public string Credit_Card { get; set; }

        [StringLength(8)]
        public string Code { get; set; }

        public decimal? Price { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
