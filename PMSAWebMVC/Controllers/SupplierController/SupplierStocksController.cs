﻿using PMSAWebMVC.Models;
using PMSAWebMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PMSAWebMVC.Controllers
{
    public class SupplierStocksController : BaseController
    {
        private PMSAEntities db;
        private string SupplierCode;
        private string SupplierAccount;
        public SupplierStocksController()
        {
            db = new PMSAEntities();
            SupplierCode = "S00001";
            SupplierAccount = "SE00001";
        }
        public ActionResult Index()
        {
            SupplierInfo supplierInfo = db.SupplierInfo.Find(SupplierCode);
            ViewBag.supplierName = supplierInfo.SupplierName;
            ViewBag.supplierCode = SupplierCode;
            return View();
        }
        // GET: SupplierStocks
        [HttpPost]
        public ActionResult Index([Bind(Include = "PartNumber")] SourceList SourceList)
        {
            var qeury = from sl in db.SourceList.AsEnumerable()
                        where sl.PartNumber == SourceList.PartNumber
                        select sl;
            ViewBag.supplierCode = SupplierCode;
            return View(qeury);
        }
        [HttpGet]
        public JsonResult GetSourcelistBySupplierCode(string supplierCode)
        {
            //注意  :   dataTable只接受Enumerable類別 ，所以要加上AsEnumerable()方法
            var query = from sl in db.SourceList.AsEnumerable()
                        where sl.SupplierCode == supplierCode
                        select new SourceList
                        {
                            SourceListID = sl.SourceListID,
                            PartNumber = sl.PartNumber,
                            QtyPerUnit = sl.QtyPerUnit,
                            UnitPrice = sl.UnitPrice,
                            UnitsOnOrder = sl.UnitsOnOrder,
                            UnitsInStock = sl.UnitsInStock
                        };
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
        // GET: SupplierStocks/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceList supplierStock = db.SourceList.Find(id);
            if (supplierStock == null)
            {
                return HttpNotFound();
            }
            return View(supplierStock);
        }
        // GET: SupplierStocks/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceList SourceList = db.SourceList.Find(id);
            if (SourceList == null)
            {
                return HttpNotFound();
            }
            return View(SourceList);
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult changeUnitsInStock([Bind(Include = "UnitsInStock,PartNumber,SourceListOID,SourceListID")] SourceList SourceList)
        {
            int? UnitsInStock = SourceList.UnitsInStock;
            if (UnitsInStock == null || UnitsInStock <= 0)
            {
                return Json( "<script>Swal.fire({ title: '庫存數量不得小於零', showClass: {  popup: 'animated fadeInDown faster' }, hideClass:      {      popup: 'animated fadeOutUp faster' }    })</script>" , JsonRequestBehavior.AllowGet);
            }
            SourceList a = db.SourceList.Find(SourceList.SourceListID);
            if ( a== null ) {
                return HttpNotFound();
            }
            a.UnitsInStock = (int)UnitsInStock;
            db.Entry(a).Property(ap=>ap.UnitsInStock).IsModified =true;
            db.SaveChanges();
            return Json(new { value = true }, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}