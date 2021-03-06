﻿using System;
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
        public List<Models.CfBank> list3 = null;
        public int data_count = 0;

        public int lastid = 0;

        public void Index()
        {

        }

        /*前台 新聞消息*/

        public void NewsList()
        {
            this.list = (from d in db.CfBulletin where d.status == 1 orderby d.makeTime descending select d).Take(6).ToList();
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

        public void DraftRunPG(int proposal_id, decimal target_money, DateTime now_time)
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

        public void DraftRunPP(int proposal_id, int file_id, String file_type, DateTime now_time)
        {
            var query = from d in db.CfProposalPromotion select d;
            Models.CfProposalPromotion cfp = new Models.CfProposalPromotion();

            cfp.proposal = proposal_id;
            cfp.fileid = file_id;
            cfp.filetype = file_type;
            cfp.orderNum = 1;
            cfp.makeTime = now_time;
            cfp.lastTime = now_time;
            cfp.stEnable = "Y";

            db.CfProposalPromotion.Add(cfp);
            db.SaveChanges();
        }

        /*前台 探索*/

        public void ProposalList(int page)
        {
            this.list2 = (from d in db.CfProposalV where d.used == 1 orderby d.makeTime descending select d).Skip((page*3)).Take(3).ToList();
            this.data_count = (from d in db.CfProposalV where d.used == 1 orderby d.makeTime descending select d).Count();
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

        public String ProposalImage(int id)
        {
            var query = (from f in db.CfFile join i in db.CfProposalPromotion on f.id equals i.fileid into fileGroup from f2 in fileGroup where f.id == f2.fileid & f2.proposal== id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                tempstr = filelist.secondName;
                this.lastid = filelist.id;
                // Insert any additional changes to column values.
            }

            return tempstr;
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

        public void InvestResult(int p_id)
        {
            int bank = 0;
            var query = from d in db.CfProposal where d.id == p_id select d;
            foreach (Models.CfProposal cfp in query)
            {
                bank = cfp.bank.Value;
            }
            this.list3 = (from d in db.CfBank where d.id == bank select d).ToList();
        }

    }
}