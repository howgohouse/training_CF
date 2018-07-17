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
            this.homemodel.NewsList();
            ViewData["DataListNews"] = this.homemodel.list;
            return View();
        }

        public ActionResult Draft(int id)
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

        public ActionResult ProposalList(int page)
        {
            this.homemodel.ProposalList(page);
            ViewData["DataList"] = this.homemodel.list2;
            ViewData["DataList1Class"] = "";
            ViewData["DataList1Title"] = "";
            ViewData["DataList1Title5"] = "";
            ViewData["DataList1id"] = 0;
            ViewData["DataList2Class"] = "";
            ViewData["DataList2Title"] = "";
            ViewData["DataList2Title5"] = "";
            ViewData["DataList2id"] = 0;
            ViewData["DataList3Class"] = "";
            ViewData["DataList3Title"] = "";
            ViewData["DataList3Title5"] = "";
            ViewData["DataList3id"] = 0;
            int i = 0;
            foreach (CF_ASP_NET.Models.CfProposalV a in ViewData["DataList"] as List<CF_ASP_NET.Models.CfProposalV >)
            {
                i++;
                switch (i)
                {
                    case 1:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-left";
                        break;
                    case 2:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-center";
                        break;
                    case 3:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-right";
                        break;
                }

                if (a.title.Length > 3)
                {
                    ViewData["DataList" + (i.ToString()) + "Title"] = a.title.Substring(0, 3) + "...";
                }
                else
                {
                    ViewData["DataList" + (i.ToString()) + "Title"] = a.title;
                }
                if (a.title.Length > 5)
                {
                    ViewData["DataList" + (i.ToString()) + "Title5"] = a.title.Substring(0, 5) + "...";
                }
                else
                {
                    ViewData["DataList" + (i.ToString()) + "Title5"] = a.title;
                }
                ViewData["DataList" + (i.ToString()) + "id"] = i;
            }
            ViewData["DataListLength"] = this.homemodel.list2.Count;
            ViewData["Page"] = page;
            int data_count = this.homemodel.data_count;
            int r = data_count % 3;
            int count_page = (data_count - r) / 3;
            int max_page = 0;
            int prev_page = 0;
            int next_page = 0;
            if (r > 0)
            {
                max_page = count_page;
            }
            else
            {
                max_page = count_page - 1;
            }
            prev_page = page - 1;
            if (prev_page < 0) prev_page = 0;
            next_page = page + 1;
            if (next_page > max_page) next_page = max_page;
            ViewData["prev_page"] = prev_page;
            ViewData["next_page"] = next_page;
            ViewData["disable_str1"] = "";
            if (page == 0) ViewData["disable_str1"] = "w3-disabled";
            ViewData["disable_str2"] = "";
            if (page == max_page) ViewData["disable_str2"] = "w3-disabled";
            return View();
        }

        public ActionResult ProposalListFirst(int page)
        {
            this.homemodel.ProposalList(page);
            ViewData["DataList"] = this.homemodel.list2;
            ViewData["DataList1Class"] = "";
            ViewData["DataList1Title"] = "";
            ViewData["DataList1Title5"] = "";
            ViewData["DataList1id"] = 0;
            ViewData["DataList2Class"] = "";
            ViewData["DataList2Title"] = "";
            ViewData["DataList2Title5"] = "";
            ViewData["DataList2id"] = 0;
            ViewData["DataList3Class"] = "";
            ViewData["DataList3Title"] = "";
            ViewData["DataList3Title5"] = "";
            ViewData["DataList3id"] = 0;
            int i = 0;
            foreach (CF_ASP_NET.Models.CfProposalV a in ViewData["DataList"] as List<CF_ASP_NET.Models.CfProposalV>)
            {
                i++;
                switch (i)
                {
                    case 1:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-left";
                        break;
                    case 2:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-center";
                        break;
                    case 3:
                        ViewData["DataList" + (i.ToString()) + "Class"] = "text-align-right";
                        break;
                }

                if (a.title.Length > 3)
                {
                    ViewData["DataList" + (i.ToString()) + "Title"] = a.title.Substring(0, 3) + "...";
                }
                else
                {
                    ViewData["DataList" + (i.ToString()) + "Title"] = a.title;
                }
                if (a.title.Length > 5)
                {
                    ViewData["DataList" + (i.ToString()) + "Title5"] = a.title.Substring(0, 5) + "...";
                }
                else
                {
                    ViewData["DataList" + (i.ToString()) + "Title5"] = a.title;
                }
                ViewData["DataList" + (i.ToString()) + "id"] = i;
            }
            ViewData["DataListLength"] = this.homemodel.list2.Count;
            ViewData["Page"] = page;
            int data_count = this.homemodel.data_count;
            int r = data_count % 3;
            int count_page = (data_count - r) / 3;
            int max_page = 0;
            int prev_page = 0;
            int next_page = 0;
            if (r > 0)
            {
                max_page = count_page;
            }
            else
            {
                max_page = count_page - 1;
            }
            prev_page = page - 1;
            if (prev_page < 0) prev_page = 0;
            next_page = page + 1;
            if (next_page > max_page) next_page = max_page;
            ViewData["prev_page"] = prev_page;
            ViewData["next_page"] = next_page;
            ViewData["disable_str1"] = "";
            if (page == 0) ViewData["disable_str1"] = "w3-disabled";
            ViewData["disable_str2"] = "";
            if (page == max_page) ViewData["disable_str2"] = "w3-disabled";
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
            String pimage_url = "file/show/" + this.homemodel.lastid.ToString();
            if (second_name == "webp")
            {
                pimage_url = "file/webpshow/"+ this.homemodel.lastid.ToString();
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

        public ActionResult InvestResult(int id)
        {
            this.homemodel.InvestResult(id);
            ViewData["DataList"] = this.homemodel.list3;
            return View();
        }

        public ActionResult NewsList()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult News(int id)
        {
            this.homemodel.News(id);
            ViewData["DataList"] = this.homemodel.list;
            return View();
        }

        public ActionResult NewsContent(int id)
        {
            return Content(this.homemodel.NewsContent(id));
        }
    }
}