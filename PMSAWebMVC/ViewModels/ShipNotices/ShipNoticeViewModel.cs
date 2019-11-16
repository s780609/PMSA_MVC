﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSAWebMVC.Models;


namespace PMSAWebMVC.ViewModels.ShipNotices
{
    /// <summary>
    /// 
    /// </summary>
    public class UnshipOrderDtlViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UnshipOrderDtlViewModel()
        {
            this.PRPORelation = new HashSet<PRPORelation>();
            this.PurchaseOrderReceiveDtl = new HashSet<PurchaseOrderReceiveDtl>();
            this.ShipNoticeDtl = new HashSet<ShipNoticeDtl>();
            this.POChanged1 = new HashSet<POChanged>();
        }

        public int PurchaseOrderDtlOID { get; set; }
        public string PurchaseOrderDtlCode { get; set; }
        public string PurchaseOrderID { get; set; }
        public string PartNumber { get; set; }
        public string PartName { get; set; }
        public string PartSpec { get; set; }
        public int QtyPerUnit { get; set; }
        public int TotalPartQty { get; set; }
        public int OriginalUnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int PurchaseUnitPrice { get; set; }
        public int Qty { get; set; }
        public int PurchasedQty { get; set; }
        public int GoodsInTransitQty { get; set; }
        public Nullable<int> Total { get; set; }
        public Nullable<System.DateTime> DateRequired { get; set; }
        public Nullable<System.DateTime> CommittedArrivalDate { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public Nullable<System.DateTime> ArrivedDate { get; set; }
        public Nullable<int> POChangedOID { get; set; }
        public string SourceListID { get; set; }
        public int TotalSourceListQty { get; set; }
        public string LastModifiedAccountID { get; set; }

        public virtual Part Part { get; set; }
        public virtual POChanged POChanged { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRPORelation> PRPORelation { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual SourceList SourceList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderReceiveDtl> PurchaseOrderReceiveDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShipNoticeDtl> ShipNoticeDtl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POChanged> POChanged1 { get; set; }
    }
}