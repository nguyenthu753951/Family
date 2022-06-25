using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace controller.Controllers
{
    public class HomeController : Controller

    {
        private const string gioHangSession = "gioHang";
        private DBContext db = new DBContext();


        public ActionResult Index()
        {
            return View(db.MENUs.ToList());
        }
        public ActionResult Menu(int ? page)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            var menu = db.MENUs.ToList();
            return View(menu.ToPagedList(pageNum, pageSize));
        }

        public ActionResult ChiTietMonAn(string id)
        {
            MENU menu = db.MENUs.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }
        public PartialViewResult  HeaderCart()
        {
            var GioHang = Session[gioHangSession];
            var list = new List<GioHangItem>();
            if (GioHang != null)
            {
                list = (List<GioHangItem>)GioHang;
            }            
            return PartialView(list);
        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string searchMUSIC)
        {
            return RedirectToAction("Search", "Home", new { key = searchMUSIC });
        }
    }
}