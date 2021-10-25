using controller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace controller.Controllers
{
    public class GioHangController : Controller
    {
        private DBContext db = new DBContext();

        private const string gioHangSession = "gioHang";
        // GET: GioHang
        public ActionResult Index()
        {
            var GioHang = Session[gioHangSession];
            var list = new List<GioHangItem>();
            if (GioHang != null)
            {
                list = (List<GioHangItem>)GioHang;
            }

            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[gioHangSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(string id)
        {
            var sessionCart = (List<GioHangItem>)Session[gioHangSession];
            sessionCart.RemoveAll(x => x.monAn.MA_MON_AN == id);
            Session[gioHangSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            var jsonCart = new JavaScriptSerializer().Deserialize<List<GioHangItem>>(cartModel);
            var sessionCart =(List<GioHangItem>) Session[gioHangSession];
            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.monAn.MA_MON_AN == item.monAn.MA_MON_AN);
                if (jsonItem!=null)
                {
                    item.sO_LUONG = jsonItem.sO_LUONG;
                }    
            }
            Session[cartModel] = sessionCart;
            return Json(new
            {
                status= true
            });
        }
        public ActionResult ThemVaoGioHang(string maMonAn, int soLuong)
        {         
            
            var GioHang = Session[gioHangSession];
            if (GioHang != null) 
            {
                var list = (List<GioHangItem>)GioHang;
                if (list.Exists(x => x.monAn.MA_MON_AN == maMonAn))
                {
                    foreach(var item in list)
                    {
                        if(item.monAn.MA_MON_AN == maMonAn)
                        {
                            item.sO_LUONG = item.sO_LUONG + soLuong;
                        }    
                    }    
                }else
                {
                    var monAn = db.MENUs.Find(maMonAn);
                    var item = new GioHangItem();
                    item.monAn = monAn;
                    item.sO_LUONG = soLuong;
                    list.Add(item);
                }                    
            } 
            else
            {
                var monAn = db.MENUs.Find(maMonAn);
                var item = new GioHangItem();
                item.monAn =  monAn;
                item.sO_LUONG = soLuong;
                var list = new List<GioHangItem>();
                list.Add(item);
                Session[gioHangSession] = list;
            }
            return RedirectToAction("index");
        }

    }
}
