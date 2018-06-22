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

        public int lastid = 0;

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

        /*前台 提案*/

        //新增方案表單

        public void DraftRunMen(String name,String phone,DateTime now_time)
        {
            var query = from d in db.CfMember select d;
            Models.CfMember cfm = new Models.CfMember();

            cfm.name = name;
            cfm.phone = phone;
            cfm.makeTime = now_time;
            cfm.stEnable = "Y";

            db.CfMember.Add(cfm);
            db.SaveChanges();

            this.lastid = cfm.id;
        }

        public void DraftRunB(int menber_id,String bank_code,String bank_name,String account_code,String account_name, DateTime now_time)
        {
            var query = from d in db.CfBank select d;
            Models.CfBank cfb = new Models.CfBank();

            cfb.member = menber_id;
            cfb.bankCdoe = bank_code;
            cfb.bankName = bank_name;
            cfb.accountCdoe = account_code;
            cfb.accountName = account_name;
            cfb.makeTime = now_time;
            cfb.lastTime = now_time;
            cfb.stEnable = "Y";

            db.CfBank.Add(cfb);
            db.SaveChanges();

            this.lastid = cfb.id;
        }

        public void DraftRunP(int menber_id, int bank_id, DateTime now_time)
        {
            var query = from d in db.CfProposal select d;
            Models.CfProposal cfp = new Models.CfProposal();

            cfp.member = menber_id;
            cfp.bank = bank_id;
            cfp.makeTime = now_time;
            cfp.lastTime = now_time;
            cfp.stEnable = "Y";

            db.CfProposal.Add(cfp);
            db.SaveChanges();

            this.lastid = cfp.id;
        }

        public void DraftRunPV(int proposal_id, String title, String introduction, String content, DateTime end_datetime_2, DateTime now_time)
        {
            var query = from d in db.CfProposalV select d;
            Models.CfProposalV cfp = new Models.CfProposalV();

            cfp.title = title;
            cfp.proposal = proposal_id;
            cfp.used = 0;
            cfp.status = 1;
            cfp.introduction = introduction;
            cfp.content = content;
            cfp.startTime = now_time;
            cfp.endTime = end_datetime_2;
            cfp.makeTime = now_time;
            cfp.lastTime = now_time;
            cfp.stEnable = "Y";

            db.CfProposalV.Add(cfp);
            db.SaveChanges();

            this.lastid = cfp.id;
        }

        public void DraftRunPG(int proposal_id,decimal target_money, DateTime now_time)
        {
            var query = from d in db.CfProposalGoal select d;
            Models.CfProposalGoal cfp = new Models.CfProposalGoal();

            cfp.proposal = proposal_id;
            cfp.targetColumn = target_money;
            cfp.orderNum = 1;
            cfp.makeTime = now_time;
            cfp.lastTime = now_time;
            cfp.stEnable = "Y";

            db.CfProposalGoal.Add(cfp);
            db.SaveChanges();

            this.lastid = cfp.id;
        }

        /*前台 探索*/

        public void ProposalList()
        {
            this.list2 = (from d in db.CfProposalV where d.used == 1 orderby d.makeTime descending select d).ToList();
        }

        public void Proposal(int id)
        {
            this.list2 = (from d in db.CfProposalV where d.proposal == id & d.used ==1 & d.status==3 select d).ToList();
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

        public void InvestIRun(int p_id, String name, String phone, decimal invest_money, DateTime now_time)
        {
            var query = from d in db.CfInvestment select d;
            Models.CfInvestment cfi = new Models.CfInvestment();

            cfi.name = name;
            cfi.phone = phone;
            cfi.invColumn = invest_money;
            cfi.makeTime = now_time;
            cfi.lastTime = now_time;
            cfi.stEnable = "Y";

            db.CfInvestment.Add(cfi);
            db.SaveChanges();

            this.lastid = cfi.ID;
        }

        public void InvestRsetRun(int p_id, decimal invest_money)
        {
            System.DateTime nowTime = System.DateTime.Now;
            var query = from d in db.CfProposalGoal where d.proposal== p_id select d;

            foreach (Models.CfProposalGoal cfp in query)
            {
                cfp.totalColumn = cfp.totalColumn + invest_money;
                cfp.lastTime = nowTime;
                // Insert any additional changes to column values.
            }

            db.SaveChanges();

        }

    }
}