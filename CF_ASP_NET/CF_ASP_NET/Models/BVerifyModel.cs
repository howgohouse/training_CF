using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_ASP_NET.Models
{
    /*前台 審核*/

    public class BVerifyModel
    {
        CrowdfundingEntities db = new CrowdfundingEntities();
        public List<Models.CfBulletin> list = null;
        public List<Models.CfProposalV> list2 = null;

        public void Index()
        {

        }

        public void ProposalList()
        {
            this.list2 = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.makeTime descending select d).ToList();
        }

        public void Proposal(int id)
        {
            this.list2 = (from d in db.CfProposalV where d.id == id select d).ToList();
        }

        public String ProposalContent(int id)
        {
            var query = (from d in db.CfProposalV where d.id == id select d).ToList();
            String tempstr = "";

            foreach (Models.CfProposalV proposal in query)
            {
                tempstr = proposal.content;
                // Insert any additional changes to column values.
            }

            return HttpUtility.HtmlDecode(tempstr);
        }

    }
}