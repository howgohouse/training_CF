using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class HomeController : Controller
    {
        public Models.HomeModel homemodel = new Models.HomeModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsList()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult News()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NewsContent()
        {
            ViewBag.Message = "Your contact page.";

            return Content("");
        }
    }
}