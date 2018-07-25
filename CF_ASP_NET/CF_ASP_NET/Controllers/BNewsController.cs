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
            int data_count = this.newsmodel.data_count;
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
            if (page == 0 | data_count == 0) ViewData["disable_str1"] = "w3-disabled";
            ViewData["disable_str2"] = "";
            if (page == max_page | data_count == 0) ViewData["disable_str2"] = "w3-disabled";
            ViewData["OrderBy"] = order_by;
            ViewData["Keyword"] = keyword;
            ViewData["DescAsc"] = desc_or_asc;
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