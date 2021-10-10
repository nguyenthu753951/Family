using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace controller.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        public ActionResult Index()
        {
            var listnhanvien = new DBContext().NHAN_VIEN.ToList();
            return View(listnhanvien);
        }

        // GET: Nhanvien/Details/5
        public ActionResult Permission(int id)
        {

            return View();
        }

        // GET: Nhanvien/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            var context = new DBContext();
            var nhanVien = context.NHAN_VIEN.Find(id);
            return View(nhanVien);
        }


        // GET: Nhanvien/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: Nhanvien/Create
        [HttpPost]
        public ActionResult Create(NHAN_VIEN model)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new DBContext();
                long MaNV = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                model.MA_NV = MaNV;
                context.NHAN_VIEN.Add(model);                
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nhanvien/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new DBContext();
            var editing = context.NHAN_VIEN.Find(id);
            return View(editing);
        }

        // POST: Nhanvien/Edit/5
        [HttpPost]
        public ActionResult Edit(NHAN_VIEN model)
        {
            try
            {
                // TODO: Add update logic here
                var context = new DBContext();
                var oldItem = context.NHAN_VIEN.Find(model.MA_NV);
                oldItem.HO_TEN_NV = model.HO_TEN_NV;
                oldItem.PHAI = model.PHAI;
                oldItem.CHUC_VU = model.CHUC_VU;
                oldItem.SDT = model.SDT;
                oldItem.NGAY_SINH = model.NGAY_SINH;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nhanvien/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new DBContext();
            var deleteing = context.NHAN_VIEN.Find(id);
            return View(deleteing);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new DBContext();
                var deleteing = context.NHAN_VIEN.Find(id);
                context.NHAN_VIEN.Remove(deleteing);
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
