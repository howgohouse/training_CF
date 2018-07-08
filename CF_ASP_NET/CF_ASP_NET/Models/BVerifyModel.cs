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
        public List<Models.CfProposalV> list = null;
        public List<Models.CfMember> list2 = null;
        public List<Models.CfBank> list3 = null;
        public List<Models.CfProposalGoal> list4 = null;

        public int lastid = 0;

        public void Index()
        {

        }

        public void ProposalList(int page, String order_by, String desc_or_asc, String keyword)
        {
            switch (order_by)
            {
                case "title":
                    if (desc_or_asc=="asc")
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.title ascending orderby d.id ascending select d).ToList();
                    }
                    else
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.title descending orderby d.id ascending select d).ToList();
                    }
                    
                    break;
                case "end_time":
                    if (desc_or_asc=="asc")
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.endTime ascending orderby d.id ascending select d).ToList();
                    }
                    else
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.endTime descending orderby d.id ascending select d).ToList();
                    }
                    
                    break;
                default:
                    if (desc_or_asc=="desc")
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.makeTime descending orderby d.id ascending select d).ToList();
                    }
                    else
                    {
                        this.list = (from d in db.CfProposalV join p in db.CfProposal on d.proposal equals p.id into pGroup from d2 in pGroup orderby d.makeTime ascending orderby d.id ascending select d).ToList();
                    }
                    
                    break;
            }

            if(keyword != "")
            {
                this.list = this.list.Where(d => d.title == keyword).Skip((page * 10)).Take(10).ToList();
            }
            else
            {
                this.list = this.list.Skip((page * 10)).Take(10).ToList();
            }
            
        }

        public void Proposal(int id)
        {
            int mem_id = 0;
            int bank_id = 0;
            this.list = (from d in db.CfProposalV where d.proposal == id select d).ToList();
            var query = (from d in db.CfProposal where d.id == id select d).ToList();
            foreach (Models.CfProposal proposal in query)
            {
                mem_id = proposal.member.Value;
                bank_id = proposal.bank.Value;
            }
            this.list2 = (from d in db.CfMember where d.id == mem_id select d).ToList();
            this.list3 = (from d in db.CfBank where d.id == bank_id select d).ToList();
            this.list4 = (from d in db.CfProposalGoal where d.proposal == id select d).ToList();
        }

        public String ProposalContent(int id)
        {
            var query = (from d in db.CfProposalV where d.proposal == id select d).ToList();
            String tempstr = "";

            foreach (Models.CfProposalV proposal in query)
            {
                tempstr = proposal.content;
                // Insert any additional changes to column values.
            }

            return HttpUtility.HtmlDecode(tempstr);
        }

        public String ProposalImage(int id)
        {
            var query = (from f in db.CfFile join i in db.CfProposalPromotion on f.id equals i.fileid into fileGroup from f2 in fileGroup where f.id == f2.fileid & f2.proposal == id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                tempstr = filelist.secondName;
                this.lastid = filelist.id;
                // Insert any additional changes to column values.
            }

            return tempstr;
        }

        public void EditRun(int p_id)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfProposalV where d.proposal == p_id select d;

            foreach (Models.CfProposalV cfp in query)
            {
                cfp.used = 1;
                cfp.status = 3;
                cfp.lastTime = nowTime;
                // Insert any additional changes to column values.
            }

            db.SaveChanges();
        }

        public void DeleteRun(int p_id)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfProposalComment where d.proposal == p_id select d;

            foreach (Models.CfProposalComment cfp in query)
            {
                db.CfProposalComment.Remove(cfp);
                // Insert any additional changes to column values.
            }

            var query2 = from d in db.CfProposalGoal where d.proposal == p_id select d;

            foreach (Models.CfProposalGoal cfp in query2)
            {
                db.CfProposalGoal.Remove(cfp);
                // Insert any additional changes to column values.
            }

            var query3 = from d in db.CfProposalPromotion where d.proposal == p_id select d;

            foreach (Models.CfProposalPromotion cfp in query3)
            {
                db.CfProposalPromotion.Remove(cfp);
                // Insert any additional changes to column values.
            }

            var query4 = from d in db.CfProposalVerify where d.proposal == p_id select d;

            foreach (Models.CfProposalVerify cfp in query4)
            {
                db.CfProposalVerify.Remove(cfp);
                // Insert any additional changes to column values.
            }

            var query5 = from d in db.CfProposalV where d.proposal == p_id select d;

            foreach (Models.CfProposalV cfp in query5)
            {
                db.CfProposalV.Remove(cfp);
                // Insert any additional changes to column values.
            }

            var query6 = from d in db.CfProposal where d.id== p_id select d;

            foreach (Models.CfProposal cfp in query6)
            {
                db.CfProposal.Remove(cfp);
                // Insert any additional changes to column values.
            }

            db.SaveChanges();
        }

    }
}