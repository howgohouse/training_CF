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

        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult DraftRun(String name,String phone,String bank_code,String bank_name,String account_code,String account_name, decimal target_money,String end_datetime,String title,String introduction,String content)
        {
            DateTime now_time = DateTime.Now;
            DateTime end_datetime_2 = Convert.ToDateTime(end_datetime);

            homemodel.DraftRunMen(name,phone,now_time);
            int menber_id = homemodel.lastid;

            homemodel = new Models.HomeModel();

            homemodel.DraftRunB(menber_id, bank_code, bank_name, account_code, account_name, now_time);
            int bank_id = homemodel.lastid;

            homemodel = new Models.HomeModel();

            homemodel.DraftRunP(menber_id, bank_id, now_time);
            int proposal_id = homemodel.lastid;

            homemodel = new Models.HomeModel();

            homemodel.DraftRunPV(proposal_id, title, introduction, content, end_datetime_2, now_time);

            homemodel = new Models.HomeModel();

            homemodel.DraftRunPG(proposal_id, target_money, now_time);

            return Content("ok");
        }

        public ActionResult Invest()
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