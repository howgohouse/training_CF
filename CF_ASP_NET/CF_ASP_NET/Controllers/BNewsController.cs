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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsContent(int id)
        {
            return Content(this.newsmodel.NewsContent(id));
        }

        public ActionResult NewsAdd()
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
    }
}