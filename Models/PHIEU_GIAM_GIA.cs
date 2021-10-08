namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHIEU_GIAM_GIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEU_GIAM_GIA()
        {
            CT_SDPGG = new HashSet<CT_SDPGG>();
        }

        [Key]
        [StringLength(10)]
        public string SO_PGG { get; set; }

        [StringLength(50)]
        public string LOAI_PGG { get; set; }

        public DateTime? HSD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_SDPGG> CT_SDPGG { get; set; }
    }
}
