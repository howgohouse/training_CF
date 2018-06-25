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

        public string mUrl = "http://192.168.2.113/";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult DraftRun(String name, String phone, String bank_code, String bank_name, String account_code, String account_name, decimal target_money, String end_datetime, String title, String introduction, String content)
        {
            DateTime now_time = DateTime.Now;
            DateTime end_datetime_2 = Convert.ToDateTime(end_datetime);

            this.homemodel.DraftRunMen(name, phone, now_time);
            int menber_id = this.homemodel.lastid;

            this.homemodel = new Models.HomeModel();

            this.homemodel.DraftRunB(menber_id, bank_code, bank_name, account_code, account_name, now_time);
            int bank_id = this.homemodel.lastid;

            this.homemodel = new Models.HomeModel();

            this.homemodel.DraftRunP(menber_id, bank_id, now_time);
            int proposal_id = this.homemodel.lastid;

            this.homemodel = new Models.HomeModel();

            this.homemodel.DraftRunPV(proposal_id, title, introduction, content, end_datetime_2, now_time);

            this.homemodel = new Models.HomeModel();

            this.homemodel.DraftRunPG(proposal_id, target_money, now_time);

            String sb = "";

            sb = sb + "{";
            sb = sb + "\"p_id\": " + proposal_id.ToString() + "  ";
            sb = sb + "}";
            return Content(sb);
        }

        public ActionResult Invest(int id)
        {
            this.homemodel.Proposal(id);
            ViewData["DataList"] = this.homemodel.list2;
            return View();
        }

        public ActionResult ProposalContent(int id)
        {
            //ViewBag.Message = "Your application description page.";

            return Content(this.homemodel.ProposalContent(id));
        }

        public ActionResult ProposalImage(int id)
        {
            //ViewBag.Message = "Your application description page.";
            String second_name = this.homemodel.ProposalImage(id);
            String pimage_url = mUrl + "file/show/" + this.homemodel.lastid.ToString();
            if (second_name == "webp")
            {
                pimage_url = mUrl+"file/webpshow/"+ this.homemodel.lastid.ToString();
            }
            

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"second_name\": \"" + second_name +"\" , ";
            sb = sb + "\"url\":\"" + pimage_url + "\"";
            sb = sb + "}";

            return Content(sb);
        }

        public ActionResult InvestRun(int p_id, String name, String phone, decimal invest_money)
        {
            DateTime now_time = DateTime.Now;

            this.homemodel.InvestIRun(p_id, name, phone, invest_money, now_time);

            this.homemodel = new Models.HomeModel();

            this.homemodel.InvestRsetRun(p_id, invest_money);

            return Content("ok");
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