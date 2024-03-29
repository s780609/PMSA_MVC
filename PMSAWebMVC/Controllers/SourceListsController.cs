﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMSAWebMVC.Models;


namespace PMSAWebMVC.Controllers
{
    public class SourceListsController : BaseController
    {
        //Test//
        private PMSAEntities db = new PMSAEntities();
        //string SourceListID2;

        // GET: SourceLists貨源清單
        public ActionResult Index()
        {
            var sourceList = db.SourceList.Include(s => s.Part).Include(s => s.SupplierInfo);
            
            return View(sourceList);
        }
    

        // GET: SourceLists/Details/5貨源清單檢視畫面
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceList sourceList = db.SourceList.Find(id);
            if (sourceList == null)
            {
                return HttpNotFound();
            }
            return View(sourceList);
        }

        // GET: SourceLists/Create貨源清單新增畫面
        public ActionResult Create()
        {
            //var q=from p in db.SourceList select p.PartNumber

            ViewBag.PartNumber = new SelectList(db.Part, "PartNumber", "PartName");
            ViewBag.SupplierCode = new SelectList(db.SupplierInfo, "SupplierCode", "SupplierName");
            return View();
        }
  

        // POST: SourceLists/Create 貨源清單新增
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SourceListOID,SourceListID,PartNumber,QtyPerUnit,MOQ,UnitPrice,SupplierCode,UnitsInStock,UnitsOnOrder,SafetyQty,EXP")] SourceList sourceList)
        {
            if (ModelState.IsValid)
            {
                sourceList.UnitsInStock = 0;
                sourceList.UnitsOnOrder = 0;
                sourceList.SourceListID = sourceList.PartNumber + "-" + sourceList.SupplierCode;
                db.SourceList.Add(sourceList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartNumber = new SelectList(db.Part, "PartNumber", "PartName", sourceList.PartNumber);
            ViewBag.SupplierCode = new SelectList(db.SupplierInfo, "SupplierCode", "SupplierName", sourceList.SupplierCode);
            return View(sourceList);
        }



        // GET: SourceLists/Edit/5 貨源清單編輯畫面
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceList sourceList = db.SourceList.Find(id);
            if (sourceList == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartNumber = new SelectList(db.Part, "PartNumber", "PartName", sourceList.PartNumber);
            ViewBag.SupplierCode = new SelectList(db.SupplierInfo, "SupplierCode", "SupplierName", sourceList.SupplierCode);
            return View(sourceList);
        }

        // POST: SourceLists/Edit/5 貨源清單編輯
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SourceListOID,SourceListID,PartNumber,QtyPerUnit,MOQ,UnitPrice,SupplierCode,UnitsInStock,UnitsOnOrder,SafetyQty,EXP")] SourceList sourceList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sourceList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartNumber = new SelectList(db.Part, "PartNumber", "PartName", sourceList.PartNumber);
            ViewBag.SupplierCode = new SelectList(db.SupplierInfo, "SupplierCode", "SupplierName", sourceList.SupplierCode);
            return View(sourceList);
        }

        // GET: SourceLists/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    SourceList sourceList = db.SourceList.Find(id);
        //    if (sourceList == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sourceList);
        //}

        //貨源清單刪除
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SourceList sourceList = db.SourceList.Find(id);
                if (sourceList == null)
                {
                    return HttpNotFound();
                }
                db.SourceList.Remove(sourceList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return Content("<script> alert('刪除失敗');window.location.href='../Index'</script>");
            }

        }

        // POST: SourceLists/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    SourceList sourceList = db.SourceList.Find(id);
        //    db.SourceList.Remove(sourceList);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }






/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
/// <returns></returns>







        // GET: SourceListsDtl貨源清單明細
        public ActionResult IndexDtl()
        {
            var sourceListDtl = db.SourceListDtl.Include(s => s.SourceList);

            

            return View(sourceListDtl);
        }
        
        // GET: SourceListDtls/Details/5 貨源清單明細檢視畫面
        public ActionResult DetailsDtl(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceListDtl sourceListDtl = db.SourceListDtl.Find(id);
            if (sourceListDtl == null)
            {
                return HttpNotFound();
            }
            return View(sourceListDtl);
        }


        // GET: SourceListDtls/Create貨源清單明細新增畫面
        public ActionResult CreateDtl()
        {
            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "SourceListID");
            SourceListDtl s = new SourceListDtl();
            s.DiscountBeginDate = DateTime.Now;
            s.DiscountEndDate = DateTime.Now.AddDays(1);
            return View(s);
        }
        // GET: SourceListDtls/Create貨源清單明細新增畫面
        //[HttpPost]
        public ActionResult CreateDtl2(string id)
        {
            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "PartNumber");
            ViewBag.SourceListIDD = id;

            SourceListDtl s = new SourceListDtl();
            s.SourceListID = id;
            s.DiscountBeginDate = DateTime.Now;
            s.DiscountEndDate = DateTime.Now.AddDays(1);
            return View(s);
            //ViewBag.PartNumber = new SelectList(db.Part, "PartNumber", "PartName");
            //ViewBag.SupplierCode = new SelectList(db.SupplierInfo, "SupplierCode", "SupplierName");
            //return View();
        }
        

        // POST: SourceListDtls/Create 貨源清單明細新增 失敗!!!!!!!!!!!!!!!
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDtl([Bind(Include = "SourceListDtlOID,SourceListID,QtyDemanded,Discount,DiscountBeginDate,DiscountEndDate,CreateDate")] SourceListDtl sourceListDtl)
        {
            if (ModelState.IsValid)
            {
                sourceListDtl.CreateDate = DateTime.Now;
                db.SourceListDtl.Add(sourceListDtl);
                db.SaveChanges();
                return RedirectToAction("IndexDtl");
            }

            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "PartNumber", sourceListDtl.SourceListID);
            return View(sourceListDtl);
        }

        // POST: SourceListDtls/Create 貨源清單明細新增 
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDtl2([Bind(Include = "SourceListDtlOID,SourceListID,QtyDemanded,Discount,DiscountBeginDate,DiscountEndDate,CreateDate")] SourceListDtl sourceListDtl)
        {
            if (ModelState.IsValid)
            {
                //SourceList s = this.db.SourceList.Find(sourceList.PartNumber);
                //db.Entry(s).State = EntityState.Detached;
                //sourceList.PartNumber = s.PartNumber;
                sourceListDtl.CreateDate = DateTime.Now;
                //sourceListDtl.Discount = (((-sourceListDtl.Discount) + 100) / 100);

                db.SourceListDtl.Add(sourceListDtl);
                db.SaveChanges();
                return RedirectToAction("IndexDtl");
            }

            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "PartNumber", sourceListDtl.SourceListID);
            return View(sourceListDtl);
        }


        // GET: SourceListDtls/Edit/5 貨源清單明細編輯畫面
        public ActionResult EditDtl(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SourceListDtl sourceListDtl = db.SourceListDtl.Find(id);
            if (sourceListDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "PartNumber", sourceListDtl.SourceListID);
            return View(sourceListDtl);
        }

        // POST: SourceListDtls/Edit/5  貨源清單明細編輯
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDtl([Bind(Include = "SourceListDtlOID,SourceListID,QtyDemanded,Discount,DiscountBeginDate,DiscountEndDate,CreateDate")] SourceListDtl sourceListDtl)
        {
            if (ModelState.IsValid)
            {
                sourceListDtl.Discount = (((-sourceListDtl.Discount) + 100) / 100);
                db.Entry(sourceListDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDtl");
            }
            ViewBag.SourceListID = new SelectList(db.SourceList, "SourceListID", "PartNumber", sourceListDtl.SourceListID);
            return View(sourceListDtl);
        }
        // GET: SourceListDtls/Delete/5 貨源清單明細不換頁刪除
        [HttpPost]
        public ActionResult DeleteDtl(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                SourceListDtl sourceListDtl = db.SourceListDtl.Find(id);
                if (sourceListDtl == null)
                {
                    return HttpNotFound();
                }
                db.SourceListDtl.Remove(sourceListDtl);
                db.SaveChanges();
                return RedirectToAction("IndexDtl");
            }
            catch
            {
                return Content("<script> alert('刪除失敗');window.location.href='../Index'</script>");
            }
           
        }


    }
}
