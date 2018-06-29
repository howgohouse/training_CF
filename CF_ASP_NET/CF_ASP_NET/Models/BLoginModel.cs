using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CF_ASP_NET.Models
{
    /*後台 新聞消息*/

    public class BLoginModel
    {
        CrowdfundingEntities db = new CrowdfundingEntities();
        public List<Models.CfAccount> list = null;

        public void Index()
        {

        }

        public Boolean LoginRun(String pword)
        {
            var query = (from a in db.CfAccount join a2 in db.CfAccount2 on a.id equals a2.account into accountGroup from a2 in accountGroup where a.id == 1 & a2.account == 1 & a2.passMd == pword select a);

            int num = 0;

            foreach (Models.CfAccount accountlist in query)
            {
                num++;
            }

            if(num!=0) return true;

            return false;
        }

    }
}