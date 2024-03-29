﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PMSAWebMVC.ViewModels.BuyerSupAccount
{
    public class BuyerSupAccountViewModel
    {
        [DisplayName("供應商名稱")]
        public string SupplierName { get; set; }

        [DisplayName("供應商代碼")]
        public string SupplierCode { get; set; }

        [DisplayName("供應商帳號")]
        public string SupplierAccountID { get; set; }

        [DisplayName("聯絡人")]
        public string ContactName { get; set; }

        [DisplayName("信箱")]
        public string Email { get; set; }

        [DisplayName("手機")]
        public string Mobile { get; set; }

        [DisplayName("市話")]
        public string Tel { get; set; }

        [DisplayName("帳號狀態")]
        public string AccountStatus { get; set; }

        [DisplayName("新增帳號者")]
        public string CreatorEmployeeID { get; set; }

        [DisplayName("修改日期")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [DisplayName("新增日期")]
        public System.DateTime CreateDate { get; set; }

        [DisplayName("寄信日期")]
        public Nullable<System.DateTime> SendLetterDate { get; set; }

        [DisplayName("使用者更改密碼日期")]
        public Nullable<System.DateTime> LastPasswordChangedDate { get; set; }
    }
}