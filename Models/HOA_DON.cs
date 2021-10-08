namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HOA_DON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOA_DON()
        {
            CT_SDPGG = new HashSet<CT_SDPGG>();
        }

        [Key]
        [StringLength(10)]
        public string MA_HD { get; set; }

        public double? TONG_TIEN_HD { get; set; }

        public DateTime? NGAY_LAP_HD { get; set; }

        public long MA_NV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_SDPGG> CT_SDPGG { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}
