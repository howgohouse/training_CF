using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_ASP_NET.Models
{
    public class HomeModel
    {
        CrowdfundingEntities db = new CrowdfundingEntities();
        public List<Models.CfBulletin> list = null;

        public void Index()
        {

        }

        /*前台 新聞消息*/

        public void NewsList()
        {
            this.list = (from d in db.CfBulletin orderby d.makeTime descending select d).ToList();
        }

        public void News(int id)
        {
            this.list = (from d in db.CfBulletin where d.id == id select d).ToList();
        }

        public String NewsContent(int id)
        {
            var query = (from d in db.CfBulletin where d.id == id select d).ToList();
            String tempstr = "";

            foreach (Models.CfBulletin bulletin in query)
            {
                tempstr = bulletin.content;
                // Insert any additional changes to column values.
            }

            return HttpUtility.HtmlDecode(tempstr);
        }

    }
}