using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controller.Models;

namespace controller.Controllers
{
    public class KHACH_HANGController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Index()
        {
            return View(db.KHACH_HANG.ToList());
        }
        public ActionResult Details(string id)
        {
            KHACH_HANG kh = (KHACH_HANG)Session["TaiKhoan"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kh.MA_KH = id;
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_KH,TEN_KH,DIA_CHI_KH,SDT_KH")] KHACH_HANG kHACH_HANG,string id)
        {
            if (ModelState.IsValid)
            {
                KHACH_HANG kh = db.KHACH_HANG.Find(id);
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("Details/" + kHACH_HANG.MA_KH);
            }

            return View(kHACH_HANG);
        }
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_KH,TEN_KH,DIA_CHI_KH,SDT_KH")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/"+kHACH_HANG.MA_KH);//(db.KHACH_HANG.Find(kHACH_HANG.MA_KH.ToString());
            }
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
