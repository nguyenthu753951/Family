using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;


namespace controller.Areas.Admin.Controllers
{
    public class checkdonhangController : Controller
    {
        // GET: Admin/checkdonhang
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            return View(db.DON_HANG.ToList());
        }
        public ActionResult Create()
        {
            return View("");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            if (dON_HANG == null)
            {
                return HttpNotFound();
            }
            return View(dON_HANG);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            CT_DONHANG ct = db.CT_DONHANG.FirstOrDefault(p=>p.MA_DH==id);
            db.CT_DONHANG.Remove(ct);
            db.SaveChanges();
            db.DON_HANG.Remove(dON_HANG);
            db.SaveChangesAsync();
            
            return RedirectToAction("Index");
        }
        public ActionResult Xacnhan(string id)
        {
            DON_HANG dON_HANG = db.DON_HANG.Find(id);
            db.SaveChanges();
            return RedirectToAction("Xacnhan");
        }
    }
}