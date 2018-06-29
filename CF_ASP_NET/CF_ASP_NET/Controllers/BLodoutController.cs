using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class BLogoutController : Controller
    {
        public ActionResult Index()
        {
            //建立
            //Session.Add("islogin", true);
            //or
            //Session["islogin"] = true;
            //取值
            //string s = Session["islogin"].ToString();
            //移除
            Session.Remove("islogin");
            return View();
        }
    }
}