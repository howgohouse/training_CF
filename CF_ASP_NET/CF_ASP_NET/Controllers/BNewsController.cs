using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CF_ASP_NET.Controllers
{
    public class BNewsController : Controller
    {
        public Models.BNewsModel newsmodel = new Models.BNewsModel();

        public ActionResult Index(int page, String order_by, String desc_or_asc, String keyword)
        {
            this.newsmodel.NewsList(page, order_by, desc_or_asc, keyword);
            ViewData["DataList"] = this.newsmodel.list;
            ViewData["DataListLength"] = this.newsmodel.list.Count;
            ViewData["Page"] = page;
            return View();
        }

        public ActionResult NewsContent(int id)
        {
            return Content(this.newsmodel.NewsContent(id));
        }

        public ActionResult NewsAdd(int id)
        {
            return View();
        }

        public ActionResult NewsAddRun(String title, String content)
        {
            this.newsmodel.NewsAddRun(title,content);

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"ok\"";
            sb = sb + "}";

            return Content(sb);
        }

        public ActionResult NewsEdit(int id)
        {
            this.newsmodel.NewsEdit(id);
            ViewData["DataList"] = this.newsmodel.list;
            return View();
        }

        public ActionResult NewsEditRun(int n_id, String title, String content)
        {
            this.newsmodel.NewsEditRun(n_id, title, content);

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"ok\"";
            sb = sb + "}";

            return Content(sb);
        }

        public ActionResult NewsChangeRun(int n_id, int value)
        {
            this.newsmodel.NewsChangeRun(n_id, value);

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"ok\"";
            sb = sb + "}";

            return Content(sb);
        }

        public ActionResult NewsDelete(int n_id)
        {
            this.newsmodel.NewsDelete(n_id);

            String sb = "";
            sb = sb + "{";
            sb = sb + "\"ok\":\"ok\"";
            sb = sb + "}";

            return Content(sb);
        }
    }
}