namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_SDPGG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MA_HD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SO_PGG { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MA_MON_AN { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string MA_DH { get; set; }

        public virtual CT_DONHANG CT_DONHANG { get; set; }

        public virtual HOA_DON HOA_DON { get; set; }

        public virtual PHIEU_GIAM_GIA PHIEU_GIAM_GIA { get; set; }
    }
}
