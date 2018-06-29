using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class BLoginController : Controller
    {
        public Models.BLoginModel loginmodel = new Models.BLoginModel();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginRun(String pword)
        {
            String ans = "error";
            if (this.loginmodel.LoginRun(pword))
            {
                ans = "ok";

                //建立
                Session.Add("islogin", "true");
                //or
                //Session["islogin"] = true;
                //取值
                //string s = Session["islogin"].ToString();
                //移除
                //Session.Remove("islogin");
            }

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"" + ans + "\"";
            sb = sb + "}";
            return Content(sb);
        }
    }
}