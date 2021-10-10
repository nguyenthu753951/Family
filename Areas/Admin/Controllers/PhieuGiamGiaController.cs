using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using controller.Models;

namespace controller.Areas.Admin.Controllers
{
    public class PhieuGiamGiaController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/PhieuGiamGia
        public ActionResult Index()
        {
            return View(db.PHIEU_GIAM_GIA.ToList());
        }

        // GET: Admin/PhieuGiamGia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_GIAM_GIA pHIEU_GIAM_GIA = db.PHIEU_GIAM_GIA.Find(id);
            if (pHIEU_GIAM_GIA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_GIAM_GIA);
        }

        // GET: Admin/PhieuGiamGia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhieuGiamGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SO_PGG,LOAI_PGG,HSD")] PHIEU_GIAM_GIA pHIEU_GIAM_GIA)
        {
            if (ModelState.IsValid)
            {
                db.PHIEU_GIAM_GIA.Add(pHIEU_GIAM_GIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pHIEU_GIAM_GIA);
        }

        // GET: Admin/PhieuGiamGia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_GIAM_GIA pHIEU_GIAM_GIA = db.PHIEU_GIAM_GIA.Find(id);
            if (pHIEU_GIAM_GIA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_GIAM_GIA);
        }

        // POST: Admin/PhieuGiamGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SO_PGG,LOAI_PGG,HSD")] PHIEU_GIAM_GIA pHIEU_GIAM_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEU_GIAM_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pHIEU_GIAM_GIA);
        }

        // GET: Admin/PhieuGiamGia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_GIAM_GIA pHIEU_GIAM_GIA = db.PHIEU_GIAM_GIA.Find(id);
            if (pHIEU_GIAM_GIA == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_GIAM_GIA);
        }

        // POST: Admin/PhieuGiamGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PHIEU_GIAM_GIA pHIEU_GIAM_GIA = db.PHIEU_GIAM_GIA.Find(id);
            db.PHIEU_GIAM_GIA.Remove(pHIEU_GIAM_GIA);
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
