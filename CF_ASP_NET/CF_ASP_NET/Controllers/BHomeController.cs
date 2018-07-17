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

        public ActionResult setMurl(String url)
        {

            if (!string.IsNullOrEmpty(Session["murl"] as string))
            {
                Session.Add("murl", url);
            }
            else
            {
                Session["murl"] = url;
            }

            //建立
            Session.Add("murl", url);
                //or
                //Session["islogin"] = true;
                //取值
                //string s = Session["islogin"].ToString();
                //移除
                //Session.Remove("islogin");

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"" + "ok" + "\"";
            sb = sb + "}";
            return Content(sb);
        }
    }
}