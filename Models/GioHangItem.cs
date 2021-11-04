using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controller.Models
{
   
    [Serializable]
    public class GioHangItem
    {
        DBContext db = new DBContext();
        public string MA_MON_AN { get; set; }
        public string TEN_MON { get; set; }
        public int sO_LUONG { get; set; }
        public double GIA_MON { get; set; }
        public string HINH_ANH { get; set; }

        public double dthanhtien
        {
            get { return sO_LUONG * GIA_MON; }
        }
        public GioHangItem(string mA_MON_AN)
        {
            MA_MON_AN = mA_MON_AN;
            MENU monan = db.MENUs.Single(n => n.MA_MON_AN == MA_MON_AN);
            TEN_MON = monan.TEN_MON;
            sO_LUONG = 1;
            HINH_ANH = monan.HINH_ANH;
            GIA_MON = double.Parse(monan.GIA_MON.ToString());
        }
    }
}