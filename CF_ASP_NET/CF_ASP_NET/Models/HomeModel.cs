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
        public List<Models.CfProposalV> list2 = null;

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

        public void ProposalList()
        {
            this.list2 = (from d in db.CfProposalV where d.used == 1 orderby d.makeTime descending select d).ToList();
        }

        public void Proposal(int id)
        {
            this.list2 = (from d in db.CfProposalV where d.id == id select d).ToList();
        }

        public String ProposalContent(int id)
        {
            var query = (from d in db.CfProposalV where d.id == id select d).ToList();
            String tempstr = "";

            foreach (Models.CfProposalV bulletin in query)
            {
                tempstr = bulletin.content;
                // Insert any additional changes to column values.
            }

            return HttpUtility.HtmlDecode(tempstr);
        }

    }
}