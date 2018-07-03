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
            return View();
        }

        public ActionResult Proposal(int id)
        {
            this.verifymodel.Proposal(id);
            ViewData["DataList"] = this.verifymodel.list;
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
            String pimage_url = mUrl + "file/show/" + this.verifymodel.lastid.ToString();
            if (second_name == "webp")
            {
                pimage_url = mUrl + "file/webpshow/" + this.verifymodel.lastid.ToString();
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