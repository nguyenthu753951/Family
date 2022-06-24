using controller.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace controller.Controllers
{
    public class NguoiDungController : Controller
    {
        DBContext db = new DBContext();
        
        [HttpGet]
        public ActionResult dangky()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult dangky([Bind(Include = "MA_KH,TEN_KH,DIA_CHI_KH,SDT_KH,MATKHAU_KH,EMAIL_KH")] KHACH_HANG kh)
        {
            //var mk = collection["matkhau"];
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
                    //kh.MATKHAU_KH=mk;
                    db.KHACH_HANG.Add(kh);
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Customer/template/dkthanhcong.html"));
                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                    content = content.Replace("{{TenDN}}", kh.MA_KH);
                    content = content.Replace("{{hoten}}", kh.TEN_KH);


                    new MailHelper().SendMail(kh.EMAIL_KH, "Đăng ký Tài khoản thành công!", content);
                    new MailHelper().SendMail(toEmail, "Đăng ký Tài khoản thành công!", content);
                    db.SaveChanges();
                    ViewBag.ThongBao = "Đăng ký thành công";
                    return RedirectToAction("DangKy");
                   

                }
            }
            return View();
        }
        // GET: NguoiDung
        [HttpGet]
        

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var mk = collection["MatKhau"];
            if (ModelState.IsValid)
            { 
                if (string.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
                if (string.IsNullOrEmpty(mk))
            {
                ViewData["Loi2"] = "Cần nhập mật khẩu";
            }
                else
            {
                KHACH_HANG kh = db.KHACH_HANG.SingleOrDefault(n => n.MA_KH == tendn && n.MATKHAU_KH == mk);
                if (kh != null)
                {
                    ViewBag.ThongBao = "Đăng nhập thành công";
                    Session["TaiKhoan"] = kh;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ThongBao = "Hình Như Tên Đăng Nhập Hoặc Mật Khẩu Không Đúng(bạn nên nhập lại)"; ;
                }  
            }
            }
            return View();
        }
        public ActionResult Details()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            return View(kh);
        }
        public ActionResult Edit(string id)
        {
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            return View(kh);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( KHACH_HANG kh)
        {
            KHACH_HANG khss = (KHACH_HANG)Session["TaiKhoan"];

            if (ModelState.IsValid)
            {
                db.Entry(kh).State = EntityState.Modified;
                kh.MATKHAU_KH = khss.MATKHAU_KH;
                db.SaveChanges();
                
                return RedirectToAction("Details");
            }
            return View(kh);
        }
        

        public ActionResult dangxuat()
        {
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            if(Session["TaiKhoan"] != null)
            {
                Session["TaiKhoan"] = null;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("DangNhap","NguoiDung");
            }

        }
        public ActionResult Doimk()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Doimk(FormCollection collection)
        {
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            var qmk = db.KHACH_HANG.SingleOrDefault(n => n.MA_KH == kh.MA_KH);
            var mkcu = collection["mkcu"];
            var mkmoi = collection["mkmoi"];
            if (kh.MATKHAU_KH == mkcu)
            {
                qmk.MATKHAU_KH = mkmoi;
                db.SaveChanges();
                Session["TaiKhoan"] = null;
                return RedirectToAction("Dangnhap", "Nguoidung");
            }
            else
            {
                ViewBag.ThongBao = "Mật khẩu không chính xác";
            }
            return View();
        }
        public ActionResult Quenmk()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Quenmk(FormCollection collection)
        {
            var Email = collection["QuenMail"];
            string password = Membership.GeneratePassword(12, 1);
            KHACH_HANG tHANHVIEN = db.KHACH_HANG.SingleOrDefault(n => n.EMAIL_KH == Email );
            tHANHVIEN.MATKHAU_KH = password;
            db.SaveChanges();
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Customer/template/QuenMk.html"));
            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            content = content.Replace("{{tk}}", tHANHVIEN.MA_KH);

            content = content.Replace("{{pass}}", password);


            new MailHelper().SendMail(Email, "Đổi mật khẩu thành công!", content);
            new MailHelper().SendMail(toEmail, "Đổi mật khẩu thành công!", content);
            return RedirectToAction("/Dangnhap");
        }

    }
}