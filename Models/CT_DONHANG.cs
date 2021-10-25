namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CT_DONHANG()
        {
            CT_SDPGG = new HashSet<CT_SDPGG>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MA_MON_AN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MA_DH { get; set; }

        public int? SL { get; set; }

        [Column(TypeName = "money")]
        public decimal? GIABAN { get; set; }
        public string TEN_MON { get; set; }
        public string HINH_ANH { get; set; }
        public virtual DON_HANG DON_HANG { get; set; }

        public virtual MENU MENU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_SDPGG> CT_SDPGG { get; set; }
    }
}
