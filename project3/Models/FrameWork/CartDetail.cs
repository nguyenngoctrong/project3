namespace Models.FrameWork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartDetail
    {
        public int Id { get; set; }

        public int? Id_Cart { get; set; }

        public int? Id_Bou { get; set; }

        public int? Volume { get; set; }

        public decimal? Total_Price { get; set; }

        public virtual Bouquest Bouquest { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
