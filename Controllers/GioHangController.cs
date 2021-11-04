using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace controller.Controllers
{
    public class GioHangController : Controller
    {
        private DBContext db = new DBContext();

        public List<GioHangItem> Laygiohang()
        {
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            if (lstgiohang == null)
            {
                lstgiohang = new List<GioHangItem>();
                Session["GioHang"] = lstgiohang;
            }
            return lstgiohang;
        }
        public ActionResult  Themgiohang(string MA_MON_AN, string strURL)
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            GioHangItem product = lstgiohang.Find(n => n.MA_MON_AN == MA_MON_AN);
            if (product == null)
            {
                product = new GioHangItem(MA_MON_AN);
                lstgiohang.Add(product);
                return Redirect(strURL);

            }
            else
            {
                product.sO_LUONG++;
                return Redirect(strURL);
            }
        }
        private int Tongsoluong()
        {
            int isumsl = 0;
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            if (lstgiohang != null)
            {
                isumsl = lstgiohang.Sum(n => n.sO_LUONG);
            }
            return isumsl;
        }
        private double Tongtien()
        {
            double total = 0;
            List<GioHangItem> lstgiohang = Session["GioHang"] as List<GioHangItem>;
            if (lstgiohang != null)
            {
                total = lstgiohang.Sum(n => n.dthanhtien);
            }
            return total;
        }
        public ActionResult insertSP()
        {
            return RedirectToAction("Index", "Home");
        }
        public ActionResult GioHang()
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            if (lstgiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.tongsoluong = Tongsoluong();
            ViewBag.tongtien = Tongtien();
            return View(lstgiohang);
        }
        public ActionResult XoaSP(string MA_MON_AN)
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            GioHangItem product = lstgiohang.SingleOrDefault(n => n.MA_MON_AN == MA_MON_AN);
            if (product != null)
            {
                lstgiohang.RemoveAll(n => n.MA_MON_AN == MA_MON_AN);
                return RedirectToAction("GioHang");
            }
            if (lstgiohang.Count==0)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult UpdateSP(string MA_MON_AN,FormCollection P)
        {
            List<GioHangItem> lstgiohang = Laygiohang();
            GioHangItem product = lstgiohang.SingleOrDefault(n => n.MA_MON_AN == MA_MON_AN);
            if (product != null)
            {
                product.sO_LUONG = int.Parse(P["Txtsl"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        [HttpGet]
        public ActionResult Dathang()
        {
            if(Session["TaiKhoan"] ==null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHangItem> lstgiohang = Laygiohang();
            ViewBag.tongsoluong = Tongsoluong();
            ViewBag.tongtien = Tongtien();
            return View(lstgiohang);
        }
        public ActionResult Dathang(FormCollection collection)
        {
            DON_HANG dh = new DON_HANG();
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            DTAC_TAI_XE tx = new DTAC_TAI_XE();
            List<GioHangItem> gh = Laygiohang();
            dh.MA_KH = kh.MA_KH;
            dh.MA_TX = tx.MA_TX;
            dh.NGAY_LAP_HD = DateTime.Now;
            var ngaygiao = string.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            dh.NGAY_LAP_HD = DateTime.Parse(ngaygiao);
            db.DON_HANG.Add(dh);
            db.SaveChanges();
            foreach(var item in gh)
            {
                CT_DONHANG ctdh = new CT_DONHANG();
                ctdh.MA_DH = dh.MA_DH;
                ctdh.MA_MON_AN = item.MA_MON_AN;
                ctdh.SL = item.sO_LUONG;
                ctdh.GIABAN = (decimal)item.GIA_MON;
                db.CT_DONHANG.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }

    }
}
