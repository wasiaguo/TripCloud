//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication3
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.User = new HashSet<User>();
        }
    
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Mangement { get; set; }
        public Nullable<int> TripId { get; set; }
        public Nullable<double> Eduction { get; set; }
        public Nullable<double> Consumption { get; set; }
        public Nullable<double> Shopping { get; set; }
        public Nullable<double> Landscape { get; set; }
        public Nullable<double> Religion { get; set; }
        public Nullable<double> Humanities { get; set; }
        public Nullable<double> HistoricalSite { get; set; }
    
        public virtual Trip Trip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User { get; set; }
    }
}
