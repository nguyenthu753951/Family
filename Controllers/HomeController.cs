using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace controller.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.WelcomeString = "Chào mừng bạn đến với Online Shop Rider"
            return View();
        }

        
    }
}