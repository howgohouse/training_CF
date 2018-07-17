using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class BVerifyController : Controller
    {
        /*審核*/

        public Models.BVerifyModel verifymodel = new Models.BVerifyModel();

        public string mUrl = "http://192.168.2.113/";

        public ActionResult Index(int page, String order_by, String desc_or_asc, String keyword)
        {
            if (order_by == "") order_by = "title";
            this.verifymodel.ProposalList(page, order_by, desc_or_asc, keyword);
            ViewData["DataList"] = this.verifymodel.list;
            ViewData["DataListLength"] = this.verifymodel.list.Count;
            ViewData["Page"] = page;
            int data_count = this.verifymodel.data_count;
            int r = data_count % 10;
            int count_page = (data_count - r) / 10;
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
            ViewData["OrderBy"] = order_by;
            ViewData["Keyword"] = keyword;
            ViewData["DescAsc"] = desc_or_asc;
            return View();
        }

        public ActionResult Proposal(int id)
        {
            this.verifymodel.Proposal(id);
            ViewData["DataList"] = this.verifymodel.list;
            ViewData["DataListMem"] = this.verifymodel.list2;
            ViewData["DataListBank"] = this.verifymodel.list3;
            ViewData["DataListGoal"] = this.verifymodel.list4;
            return View();
        }

        public ActionResult ProposalContent(int id)
        {
            //ViewBag.Message = "Your application description page.";

            return Content(this.verifymodel.ProposalContent(id));
        }

        public ActionResult ProposalImage(int id)
        {
            //ViewBag.Message = "Your application description page.";
            String second_name = this.verifymodel.ProposalImage(id);
            String pimage_url = "file/show/" + this.verifymodel.lastid.ToString();
            if (second_name == "webp")
            {
                pimage_url = "file/webpshow/" + this.verifymodel.lastid.ToString();
            }


            String sb = "";
            sb = sb + "{";
            sb = sb + "\"second_name\": \"" + second_name + "\" , ";
            sb = sb + "\"url\":\"" + pimage_url + "\"";
            sb = sb + "}";

            return Content(sb);
        }

        public ActionResult EditRun(int p_id, int value)
        {
            //ViewBag.Message = "Your application description page.";
            if (value == 1)
            {
                this.verifymodel.EditRun(p_id);
            }
            else
            {
                this.verifymodel.DeleteRun(p_id);
            }

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"ok\"";
            sb = sb + "}";

            return Content(sb);
        }
    }
}