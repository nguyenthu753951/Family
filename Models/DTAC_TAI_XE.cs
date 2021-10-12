namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DTAC_TAI_XE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DTAC_TAI_XE()
        {
            DON_HANG = new HashSet<DON_HANG>();
            PHIEU_GIAO_HANG = new HashSet<PHIEU_GIAO_HANG>();
        }

        [Key]
        [StringLength(10)]
        public string MA_TX { get; set; }

        [StringLength(50)]
        public string TEN_TX { get; set; }

        [StringLength(50)]
        public string DIA_CHI_TX { get; set; }

        [StringLength(15)]
        public string BIEN_SO_XE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEU_GIAO_HANG> PHIEU_GIAO_HANG { get; set; }
    }
}
