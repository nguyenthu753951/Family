namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            CT_DONHANG = new HashSet<CT_DONHANG>();
            PHIEU_GIAO_HANG = new HashSet<PHIEU_GIAO_HANG>();
        }

        [Key]
        [StringLength(10)]
        public string MA_DH { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Phí Giao Hàng")]
        public decimal? PHI_GIAO_HANG { get; set; }

        [Display(Name = "Ngày lập hóa đơn")]

        public DateTime? NGAY_LAP_HD { get; set; }

        [Display(Name = "Ngày giao")]
        public DateTime? NGAY_HEN_GIAO { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Mã khách hàng")]

        public string MA_KH { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Mã Tài xế")]

        public string MA_TX { get; set; }

        public string LOAI { get; set; }
        public string HINH_ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DONHANG> CT_DONHANG { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual DTAC_TAI_XE DTAC_TAI_XE { get; set; }

        public virtual ICollection<PHIEU_GIAO_HANG> PHIEU_GIAO_HANG { get; set; }
    }
}
