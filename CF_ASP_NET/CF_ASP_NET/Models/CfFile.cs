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
    
    public partial class CfFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CfFile()
        {
            this.CfDirFile = new HashSet<CfDirFile>();
            this.CfImage = new HashSet<CfImage>();
            this.CfImageWebp = new HashSet<CfImageWebp>();
            this.CfProposalPromotion = new HashSet<CfProposalPromotion>();
            this.CfVideo = new HashSet<CfVideo>();
        }
    
        public int id { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public System.DateTime makeTime { get; set; }
        public string stEnable { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfDirFile> CfDirFile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfImage> CfImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfImageWebp> CfImageWebp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfProposalPromotion> CfProposalPromotion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CfVideo> CfVideo { get; set; }
    }
}
