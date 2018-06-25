using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CF_ASP_NET.Models
{
    public class FileModel
    {
        CrowdfundingEntities db = new CrowdfundingEntities();
        public List<Models.CfBulletin> list = null;
        public List<Models.CfFile> list2 = null;
        public List<Models.CfImage> list3 = null;
        public List<Models.CfVideo> list4 = null;

        public String fileName = "";
        public String[] temp_str_array = {"","","",""};
        public int lastid = new int();
        public DateTime mTime = new DateTime();

        public void Index()
        {
            this.list = (from d in db.CfBulletin orderby d.makeTime descending select d).ToList();
        }

        public String Show(int id)
        {
            var query = (from f in db.CfFile join i in db.CfImage on f.id equals i.fileid into fileGroup from f2 in fileGroup where f.id == id & f2.fileid == id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                String date = filelist.makeTime.ToString("yyyy/MM/dd hh:mm:ss");
                string[] tokens = date.Split(' ');
                string[] tokens2 = tokens[0].Split('/');
                tempstr = "~/UpLoadFile/"+ tokens2[0] + "/" + tokens2[0] + "-" + tokens2[1] + "/" + tokens2[0] + "-" + tokens2[1] + "-" + tokens2[2] + "/" + filelist.id.ToString() + ".file";
                // Insert any additional changes to column values.
            }

            return tempstr;
        }

        public String WebpShow(int id)
        {
            var query = (from f in db.CfFile join i in db.CfImageWebp on f.id equals i.fileid into fileGroup from f2 in fileGroup where f.id == id & f2.fileid == id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                String date = filelist.makeTime.ToString("yyyy/MM/dd hh:mm:ss");
                string[] tokens = date.Split(' ');
                string[] tokens2 = tokens[0].Split('/');
                tempstr = "~/UpLoadFile/" + tokens2[0] + "/" + tokens2[0] + "-" + tokens2[1] + "/" + tokens2[0] + "-" + tokens2[1] + "-" + tokens2[2] + "/" + filelist.id.ToString() + ".file";
                // Insert any additional changes to column values.
            }

            return tempstr;
        }

        public String DownLoad(int id)
        {
            var query = (from f in db.CfFile where f.id == id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                String date = filelist.makeTime.ToString("yyyy/MM/dd hh:mm:ss");
                string[] tokens = date.Split(' ');
                string[] tokens2 = tokens[0].Split('/');
                tempstr = "~/UpLoadFile/" + tokens2[0] + "/" + tokens2[0] + "-" + tokens2[1] + "/" + tokens2[0] + "-" + tokens2[1] + "-" + tokens2[2] + "/" + filelist.id.ToString() + ".file";

                this.fileName = filelist.firstName + "." + filelist.secondName;
                // Insert any additional changes to column values.
            }

            return tempstr;
        }

        public String VideoStream(int id)
        {
            var query = (from f in db.CfFile join v in db.CfVideo on f.id equals v.fileid into fileGroup from f2 in fileGroup where f.id == id & f2.fileid == id select f);
            String tempstr = "";

            foreach (Models.CfFile filelist in query)
            {
                String date = filelist.makeTime.ToString("yyyy/MM/dd hh:mm:ss");
                string[] tokens = date.Split(' ');
                string[] tokens2 = tokens[0].Split('/');
                tempstr = "~/UpLoadFile/" + tokens2[0] + "/" + tokens2[0] + "-" + tokens2[1] + "/" + tokens2[0] + "-" + tokens2[1] + "-" + tokens2[2] + "/" + filelist.id.ToString() + ".file";
                // Insert any additional changes to column values.
            }

            return tempstr;
        }
        
        public int Upload(String fileName)
        {
            db = new CrowdfundingEntities();

            String[] substrings = fileName.Split('.');
            String firstname = "";
            String secondname = "";
            for (int i=0;i<(substrings.Length-1);i++)
            {
                if (i != 0)
                {
                    firstname = firstname + "." + substrings[i];
                }
                else
                {
                    firstname = substrings[i];
                }
            }
            secondname = substrings[(substrings.LongLength-1)];

            
            secondname = secondname.ToLower();

            System.DateTime nowTime = System.DateTime.Now;
            this.mTime = nowTime;
            String datestrs = nowTime.ToString("yyyy/MM/dd hh:mm:ss");
            this.temp_str_array = datestrs.Split(' ');
            this.temp_str_array = this.temp_str_array[0].Split('/');

            var query = from d in db.CfFile select d;
            Models.CfFile qfile = new Models.CfFile();
            qfile.firstName = firstname;
            qfile.secondName = secondname;
            qfile.makeTime = nowTime;
            qfile.stEnable = "Y";

            db.CfFile.Add(qfile);
            db.SaveChanges();

            this.lastid = qfile.id;

            return this.lastid;
        }

        public void Upload_2(int id, System.DateTime nowTime)
        {
            this.lastid = id;

            var query2 = from d in db.CfDirFile select d;
            Models.CfDirFile dirfile = new Models.CfDirFile()
            {
                parentDir = 1,
                fileid = this.lastid
            };

            db.CfDirFile.Add(dirfile);
            db.SaveChanges();

            //return this.lastid;
        }

        public void Upload_3(int id, System.DateTime nowTime, String path)
        {
            this.lastid = id;

            int iWidth = 0;
            int iHeight = 0;

            try
            {
                Bitmap bitmap = new Bitmap(path);

                iWidth = bitmap.Width;
                iHeight = bitmap.Height;
            }
            catch(Exception e)
            {
                iWidth = 0;
                iHeight = 0;
            }

            if (iWidth == 0 & iHeight== 0)
            {
                var query3 = from d in db.CfImageWebp select d;
                Models.CfImageWebp image = new Models.CfImageWebp()
                {
                    width = iWidth,
                    height = iHeight,
                    makeTime = nowTime,
                    fileid = this.lastid,
                    stEnable = "Y"
                };

                db.CfImageWebp.Add(image);
            }
            else
            {
                var query3 = from d in db.CfImage select d;
                Models.CfImage image = new Models.CfImage()
                {
                    width = iWidth,
                    height = iHeight,
                    makeTime = nowTime,
                    fileid = this.lastid,
                    stEnable = "Y"
                };

                db.CfImage.Add(image);
            }
            
            db.SaveChanges();

            //return this.lastid;
        }

    }

}