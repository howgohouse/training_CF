using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_ASP_NET.Models
{
    /*後台 新聞消息*/

    public class BNewsModel
    {
        CrowdfundingEntities db = new CrowdfundingEntities();
        public List<Models.CfBulletin> list = null;

        public void Index()
        {

        }

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

        public String NewsAddRun(int id2, String title2, String content2)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfBulletin select d;
            Models.CfBulletin bulletin = new Models.CfBulletin()
            {
                id = new int(),
                title = title2,
                content = content2,
                makeTime = nowTime,
                lastTime = nowTime,
                stEnable = "Y"
            };

            db.CfBulletin.Add(bulletin);

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return "error";
            }

            return HttpUtility.HtmlDecode(content2);
        }

        public void NewsEdit(int id)
        {
            this.list = (from d in db.CfBulletin where d.id == id select d).ToList();
        }

        public String NewsEditRun(int id, String title, String content)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfBulletin where d.id == id select d;

            foreach (Models.CfBulletin bulletin in query)
            {
                bulletin.title = title;
                bulletin.content = content;
                bulletin.lastTime = nowTime;
                // Insert any additional changes to column values.
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return "error";
            }

            return HttpUtility.HtmlDecode(content);
        }

        public void Add()
        {
            
        } 

        public String NewsDelete(int id)
        {
            var query = from d in db.CfBulletin where d.id == id select d;

            foreach (Models.CfBulletin bulletin in query)
            {
                db.CfBulletin.Remove(bulletin);
                // Insert any additional changes to column values.
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Provide for exceptions.
                return "error";
            }

            return HttpUtility.HtmlDecode("ok");
        }

    }
}