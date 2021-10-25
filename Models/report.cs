namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class report
    {
        public string MA_DH { get; set; }
        public string MA_KH { get; set; }
        public string TEN_MON { get; set; }
        public int? SL { get; set; }
        public DateTime? NGAY_LAP_HD { get; set; }
        public decimal? GIABAN { get; set; }
        public virtual ICollection<CT_DONHANG> CT_DONHANG { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual DTAC_TAI_XE DTAC_TAI_XE { get; set; }

        public virtual ICollection<PHIEU_GIAO_HANG> PHIEU_GIAO_HANG { get; set; }
    }
}