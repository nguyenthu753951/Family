namespace controller.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            DON_HANG = new HashSet<DON_HANG>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Tên tài khoản")]
        public string MA_KH { get; set; }


        [StringLength(20)]
        [Display(Name = "Tên Khách hàng")]
        public string TEN_KH { get; set; }


        [Display(Name = "Địa chỉ")]
        [StringLength(50)]
        public string DIA_CHI_KH { get; set; }


        [StringLength(10)]
        [Display(Name = "Số điện thoại")]
        public string SDT_KH { get; set; }


        [StringLength(10, MinimumLength = 6)]
        [Display(Name = "Mật Khẩu")]
        public string MATKHAU_KH { get; set; }


        [StringLength(40)]
        [Display(Name = "Email khách hàng")]
        public string EMAIL_KH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }
    }
}
