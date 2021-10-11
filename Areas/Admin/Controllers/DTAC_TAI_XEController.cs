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
    public class DTAC_TAI_XEController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/DTAC_TAI_XE
        public ActionResult Index()
        {
            return View(db.DTAC_TAI_XE.ToList());
        }

        // GET: Admin/DTAC_TAI_XE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTAC_TAI_XE dTAC_TAI_XE = db.DTAC_TAI_XE.Find(id);
            if (dTAC_TAI_XE == null)
            {
                return HttpNotFound();
            }
            return View(dTAC_TAI_XE);
        }

        // GET: Admin/DTAC_TAI_XE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DTAC_TAI_XE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MA_TX,TEN_TX,DIA_CHI_TX,BIEN_SO_XE")] DTAC_TAI_XE dTAC_TAI_XE)
        {
            if (ModelState.IsValid)
            {
                db.DTAC_TAI_XE.Add(dTAC_TAI_XE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dTAC_TAI_XE);
        }

        // GET: Admin/DTAC_TAI_XE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTAC_TAI_XE dTAC_TAI_XE = db.DTAC_TAI_XE.Find(id);
            if (dTAC_TAI_XE == null)
            {
                return HttpNotFound();
            }
            return View(dTAC_TAI_XE);
        }

        // POST: Admin/DTAC_TAI_XE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MA_TX,TEN_TX,DIA_CHI_TX,BIEN_SO_XE")] DTAC_TAI_XE dTAC_TAI_XE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dTAC_TAI_XE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dTAC_TAI_XE);
        }

        // GET: Admin/DTAC_TAI_XE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DTAC_TAI_XE dTAC_TAI_XE = db.DTAC_TAI_XE.Find(id);
            if (dTAC_TAI_XE == null)
            {
                return HttpNotFound();
            }
            return View(dTAC_TAI_XE);
        }

        // POST: Admin/DTAC_TAI_XE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DTAC_TAI_XE dTAC_TAI_XE = db.DTAC_TAI_XE.Find(id);
            db.DTAC_TAI_XE.Remove(dTAC_TAI_XE);
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
