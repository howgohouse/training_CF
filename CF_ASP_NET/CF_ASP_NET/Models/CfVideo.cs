//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CF_ASP_NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CfVideo
    {
        public int id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public Nullable<int> fileid { get; set; }
        public System.TimeSpan videoTime { get; set; }
        public System.DateTime makeTime { get; set; }
        public string stEnable { get; set; }
    
        public virtual CfFile CfFile { get; set; }
    }
}
