using controller.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace controller.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            var lstproduct = db.MENUs.ToList();
            return View(lstproduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MENU product)
        {
            try
            {
                if (product.ImgUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(product.ImgUpload.FileName);
                    string extension = Path.GetExtension(product.ImgUpload.FileName);
                    fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"));
                    product.HINH_ANH = fileName;
                    product.ImgUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Customer/images/"), fileName));
                }
                db.MENUs.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            var objproduct = db.MENUs.Where(n => n.MA_MON_AN == id).FirstOrDefault();
            return View(objproduct);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MENU mENU = db.MENUs.Find(id);
            db.MENUs.Remove(mENU);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var objproduct = db.MENUs.Where(n => n.MA_MON_AN == id).FirstOrDefault();
            return View(objproduct);
        }
        [HttpPost]
        public ActionResult Edit(MENU product)
        {
            if (product.ImgUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(product.ImgUpload.FileName);
                string extension = Path.GetExtension(product.ImgUpload.FileName);
                fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss") );
                product.HINH_ANH = fileName;
                product.ImgUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Customer/images/"), fileName));
            }
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}