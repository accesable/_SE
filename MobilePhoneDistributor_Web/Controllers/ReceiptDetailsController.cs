﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobilePhoneDistributor_Web.Models;

namespace MobilePhoneDistributor_Web.Controllers
{
    public class ReceiptDetailsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

       

       

       
        
        // GET: ReceiptDetails/AppendDetail
        public ActionResult AppendDetail(string id)
        {
            ViewBag.Id = id;
            ViewBag.PhoneModelId = new SelectList(db.PhoneModels, "PhoneId", "PhoneName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AppendDetail(string id,ReceiptDetailCreateViewModel model)
        {
            var receiptDetail = new ReceiptDetail()
            {
                ReceiptId = id,
                PhoneModelId = model.PhoneModelId,
                Quantity = model.Quantity,
                UnitAmmount = model.UnitAmmount,
            };
            if (ModelState.IsValid)
            {
                db.ReceiptsDetail.Add(receiptDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Details","Receipts",new { id });
            }
            ViewBag.PhoneModelId = new SelectList(db.PhoneModels, "PhoneId", "PhoneName",receiptDetail.PhoneModelId);
            return View();
        }

        // POST: ReceiptDetails/AppendDetail
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        // GET: ReceiptDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = await db.ReceiptsDetail.FindAsync(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhoneModelId = new SelectList(db.PhoneModels, "PhoneId", "PhoneName", receiptDetail.PhoneModelId);
            ViewBag.ReceiptId = new SelectList(db.Receipts, "ReceiptId", "StaffId", receiptDetail.ReceiptId);
            return View(receiptDetail);
        }

        // POST: ReceiptDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReceiptDetailId,ReceiptId,Quantity,PhoneModelId,UnitAmmount")] ReceiptDetail receiptDetail)
        {
            

            ReceiptDetail receiptDetail1 = db.ReceiptsDetail.Where(i=>i.ReceiptDetailId==receiptDetail.ReceiptDetailId).FirstOrDefault() ;
            receiptDetail1.Quantity = receiptDetail.Quantity;
            receiptDetail1.UnitAmmount = receiptDetail.UnitAmmount;
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Receipts", new { id=receiptDetail1.ReceiptId });
            /*ViewBag.PhoneModelId = new SelectList(db.PhoneModels, "PhoneId", "PhoneName", receiptDetail.PhoneModelId);
            ViewBag.ReceiptId = new SelectList(db.Receipts, "ReceiptId", "StaffId", receiptDetail.ReceiptId);
            return View(receiptDetail);*/
        }

        // GET: ReceiptDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReceiptDetail receiptDetail = await db.ReceiptsDetail.FindAsync(id);
            if (receiptDetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptDetail);
        }

        // POST: ReceiptDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReceiptDetail receiptDetail = await db.ReceiptsDetail.FindAsync(id);
            string routevalue = receiptDetail.ReceiptId;
            db.ReceiptsDetail.Remove(receiptDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", "Receipts", new { id= routevalue });
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
