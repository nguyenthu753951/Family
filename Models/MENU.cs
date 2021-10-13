namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MENU")]
    public partial class MENU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENU()
        {
            CT_DONHANG = new HashSet<CT_DONHANG>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã món ăn")]
        public string MA_MON_AN { get; set; }

        [StringLength(50)]
        [Display(Name ="Tên món ăn")]
        public string TEN_MON { get; set; }
        [Display(Name = "Giá món")]
        public double? GIA_MON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONHANG> CT_DONHANG { get; set; }
    }
}
