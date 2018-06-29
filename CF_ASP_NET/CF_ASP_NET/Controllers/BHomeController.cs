using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class BHomeController : Controller
    {
        public ActionResult Index()
        {
            String islogin = "false";
            if (!string.IsNullOrEmpty(Session["islogin"] as string))
            {
                if(Session["islogin"].ToString() == "true") islogin = "true";
            }
            ViewData["islogin"] = islogin;

            return View();
        }
    }
}