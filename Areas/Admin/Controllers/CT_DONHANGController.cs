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
    public class CT_DONHANGController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Admin/CT_DONHANG
        public ActionResult Index()
        {
            var cT_DONHANG = db.CT_DONHANG.Include(c => c.DON_HANG).Include(c => c.MENU);
            return View(cT_DONHANG.ToList());
        }

        // GET: Admin/CT_DONHANG/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DONHANG cT_DONHANG = db.CT_DONHANG.Find(id);
            if (cT_DONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DONHANG);
        }
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_DONHANG cT_DONHANG = db.CT_DONHANG.Find(id);
            if (cT_DONHANG == null)
            {
                return HttpNotFound();
            }
            return View(cT_DONHANG);
        }

        // POST: Admin/CT_DONHANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CT_DONHANG cT_DONHANG = db.CT_DONHANG.Find(id);
            db.CT_DONHANG.Remove(cT_DONHANG);
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
