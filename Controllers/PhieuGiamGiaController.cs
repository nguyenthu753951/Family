using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace controller.Controllers
{
    public class PhieuGiamGiaController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            var listphieugiamgia = new DBContext().PHIEU_GIAM_GIA.ToList();
            return View(listphieugiamgia);
        }

        // GET: PhieuGiamGia/Details/5
        public ActionResult Permission(string id)
        {

            return View();
        }

        // GET: PhieuGiamGia/Details/5

        [HttpGet]
        public ActionResult Details(string id)
        {
            var context = new DBContext();
            var phieuGiamGia = context.PHIEU_GIAM_GIA.Find(id);
            return View(phieuGiamGia);
        }


        // GET: PhieuGiamGia/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: PhieuGiamGia/Create
        [HttpPost]
        public ActionResult Create(PHIEU_GIAM_GIA model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBContext();
                context.PHIEU_GIAM_GIA.Add(model);                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PhieuGiamGia/Edit/5
        public ActionResult Edit(string id)
        {
            var context = new DBContext();
            var editing = context.PHIEU_GIAM_GIA.Find(id);
            return View(editing);
        }

        // POST: PhieuGiamGia/Edit/5
        [HttpPost]
        public ActionResult Edit(PHIEU_GIAM_GIA model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBContext();
                var oldItem = context.PHIEU_GIAM_GIA.Find(model.SO_PGG);
                oldItem.LOAI_PGG = model.LOAI_PGG;
                oldItem.HSD = model.HSD;                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET:  PhieuGiamGia/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new DBContext();
            var deleteing = context.PHIEU_GIAM_GIA.Find(id);
            return View(deleteing);
        }

        // POST:  PhieuGiamGia/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBContext();
                var deleteing = context.PHIEU_GIAM_GIA.Find(id);
                context.PHIEU_GIAM_GIA.Remove(deleteing);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
