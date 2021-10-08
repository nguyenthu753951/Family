namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHIEU_GIAO_HANG
    {
        [Key]
        [StringLength(10)]
        public string MA_PGH { get; set; }

        public DateTime? NGAY_LAP_PHIEU { get; set; }

        public DateTime? THOI_GIAN_GIAO { get; set; }

        public long MA_NV { get; set; }

        [Required]
        [StringLength(10)]
        public string MA_TX { get; set; }

        [Required]
        [StringLength(10)]
        public string MA_DH { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }

        public virtual DTAC_TAI_XE DTAC_TAI_XE { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }
    }
}
