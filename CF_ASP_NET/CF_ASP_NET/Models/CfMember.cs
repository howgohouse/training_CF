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
    
    public partial class CfMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CfMember()
        {
            this.CfBank = new HashSet<CfBank>();
            this.CfProposal = new HashSet<CfProposal>();
        }
    
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public System.DateTime makeTime { get; set; }
        public string stEnable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfBank> CfBank { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfProposal> CfProposal { get; set; }
    }
}
