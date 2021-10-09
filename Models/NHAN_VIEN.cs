namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        public NHAN_VIEN()
        {
            HOA_DON = new HashSet<HOA_DON>();
            PHIEU_GIAO_HANG = new HashSet<PHIEU_GIAO_HANG>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MA_NV { get; set; }

        [StringLength(30)]
        [Display(Name ="Họ Tên")]
        public string HO_TEN_NV { get; set; }


        [StringLength(10)]
        [Display(Name = "Phái")]

        public string PHAI { get; set; }

        [StringLength(20)]
        [Display(Name = "Chức vụ")]
        public string CHUC_VU { get; set; }

        [StringLength(10)]
        [Display(Name = "Số Điện thoại")]
        public string SDT { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime NGAY_SINH { get; set; }

        public virtual ICollection<HOA_DON> HOA_DON { get; set; }

        public virtual ICollection<PHIEU_GIAO_HANG> PHIEU_GIAO_HANG { get; set; }
    }
}
