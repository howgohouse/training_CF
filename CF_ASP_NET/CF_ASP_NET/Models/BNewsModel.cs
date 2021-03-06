﻿using System;
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
        public int data_count = 0;

        public void Index()
        {

        }

        public void NewsList(int page, String order_by, String desc_or_asc, String keyword)
        {
            switch (order_by)
            {
                case "title":
                    if (desc_or_asc=="asc")
                    {
                        this.list = (from d in db.CfBulletin orderby d.title ascending orderby d.id ascending select d).ToList();
                    }
                    else
                    {
                        this.list = (from d in db.CfBulletin orderby d.title descending orderby d.id ascending select d).ToList();
                    }
                    
                    break;
                default:
                    if (desc_or_asc=="desc")
                    {
                        this.list = (from d in db.CfBulletin orderby d.makeTime descending orderby d.id ascending select d).ToList();
                    }
                    else
                    {
                        this.list = (from d in db.CfBulletin orderby d.makeTime ascending orderby d.id ascending select d).ToList();
                    }
                    
                    break;
            }

            if (keyword != "")
            {
                this.list = this.list.Where(d => d.title == keyword).Skip((page * 10)).Take(10).ToList();
                this.data_count = (from d in db.CfBulletin orderby d.makeTime ascending orderby d.id ascending select d).Where(d => d.title == keyword).Count();
            }
            else
            {
                this.list = this.list.Skip((page * 10)).Take(10).ToList();
                this.data_count = (from d in db.CfBulletin orderby d.makeTime ascending orderby d.id ascending select d).Count();
            }
            
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

        public String NewsAddRun(String title2, String content2)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfBulletin select d;
            Models.CfBulletin bulletin = new Models.CfBulletin()
            {
                id = new int(),
                title = title2,
                content = content2,
                status = 0,
                makeTime = nowTime,
                lastTime = nowTime,
                stEnable = "Y"
            };

            db.CfBulletin.Add(bulletin);

            db.SaveChanges();

            return HttpUtility.HtmlDecode(content2);
        }

        public void NewsEdit(int id)
        {
            this.list = (from d in db.CfBulletin where d.id == id select d).ToList();
        }

        public void NewsEditRun(int n_id, String title, String content)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfBulletin where d.id == n_id select d;

            foreach (Models.CfBulletin bulletin in query)
            {
                bulletin.title = title;
                bulletin.content = content;
                bulletin.lastTime = nowTime;
                // Insert any additional changes to column values.
            }

            db.SaveChanges();
        }

        public void NewsChangeRun(int id, int value)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfBulletin where d.id == id select d;

            foreach (Models.CfBulletin bulletin in query)
            {
                bulletin.status = value;
                bulletin.lastTime = nowTime;
                // Insert any additional changes to column values.
            }

            db.SaveChanges();
        }

        public void Add()
        {
            
        } 

        public void NewsDelete(int id)
        {
            var query = from d in db.CfBulletin where d.id == id select d;

            foreach (Models.CfBulletin bulletin in query)
            {
                db.CfBulletin.Remove(bulletin);
                // Insert any additional changes to column values.
            }

            db.SaveChanges();
        }

    }
}