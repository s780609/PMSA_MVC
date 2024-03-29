//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace PMSAWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockOut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockOut()
        {
            this.StockOutDtl = new HashSet<StockOutDtl>();
        }
    
        public int StockOutOID { get; set; }
        public string StockOutID { get; set; }
        public string ShipOrderID { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> DeductStockDate { get; set; }
        public string CreateEmployeeID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string SignStatus { get; set; }
        public Nullable<int> SignFlowOID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual SignFlow SignFlow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockOutDtl> StockOutDtl { get; set; }
    }
}
