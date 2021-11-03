using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace controller.Controllers
{
    public class NguoiDungController : Controller
    {
        DBContext db = new DBContext();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "MA_KH,TEN_KH,DIA_CHI_KH,SDT_KH,MATKHAU_KH,EMAIL_KH")] KHACH_HANG kh,string id)
        {

            if (ModelState.IsValid)
            {
                if ((String.IsNullOrEmpty(kh.MA_KH)))
                {
                    ViewData["Loi1"] = "Bạn chưa nhập tên tài khoản!!";
                }
                if (String.IsNullOrEmpty(kh.MATKHAU_KH))
                {
                    ViewData["Loi2"] = "Bạn chưa nhập mật khẩu!!";
                }
                if (String.IsNullOrEmpty(kh.TEN_KH))
                {
                    ViewData["Loi3"] = "Bạn để trống họ tên !!";
                }
                if (String.IsNullOrEmpty(kh.EMAIL_KH))
                {
                    ViewData["Loi4"] = "Bạn để trống email bạn đang dùng !!";
                }
                if (String.IsNullOrEmpty(kh.DIA_CHI_KH))
                {
                    ViewData["Loi5"] = "Bạn để trống địa chỉ bạn đang ở !!";
                }
                if (String.IsNullOrEmpty(kh.SDT_KH))
                {
                    ViewData["Loi6"] = "Bạn để trống số điện thoại của bạn !!";
                }
                else
                {

                    db.KHACH_HANG.Add(kh);
                    db.SaveChanges();
                    ViewBag.ThongBao = "Đăng ký thành công";
                    return RedirectToAction("DangNhap");
                   

                }
            }
            return View();
        }
        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KHACH_HANG kh)
        {
            var tendn = collection["TenDN"];
            var mk = collection["MatKhau"];
            var hoten = collection["HoTen"];
            var email = collection["Email"];
            var diachi = collection["DiaChi"];
            var sdt = collection["SDT"];
            if (string.IsNullOrEmpty(kh.MA_KH) || mk == null || hoten == null || email == null || diachi == null || sdt == null)
            {
                ViewData["Loi1"] = "Bạn chưa nhập tên tài khoản!!";
                ViewData["Loi2"] = "Bạn chưa nhập mật khẩu!!";
                ViewData["Loi3"] = "Bạn để trống họ tên !!";
                ViewData["Loi4"] = "Bạn để trống email bạn đang dùng !!";
                ViewData["Loi5"] = "Bạn để trống địa chỉ bạn đang ở !!";
                ViewData["Loi6"] = "Bạn để trống số điện thoại của bạn !!";
            }
            else
            {
                kh.MA_KH = tendn;
                kh.MATKHAU_KH = mk;
                kh.TEN_KH = hoten;
                kh.EMAIL_KH = email;
                kh.DIA_CHI_KH = diachi;
                kh.SDT_KH = sdt;
                db.KHACH_HANG.Add(kh);
                db.SaveChanges();
                if (kh != null)
                {
                    ViewBag.ThongBao = "Đăng ký thành công";
                    return RedirectToAction("DangNhap");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {

            KHACH_HANG kh1 = new KHACH_HANG();
            var tendn = collection["TenDN"];
            var mk = collection["MatKhau"];
            KHACH_HANG kh = db.KHACH_HANG.SingleOrDefault(n => n.MA_KH == tendn && n.MATKHAU_KH == mk);
            if (!(kh == null))
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["MA_KH"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ThongBao = "Hình Như Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng(bạn nên nhập lại)"; ;
            }  
            return View();
        }
    }
}