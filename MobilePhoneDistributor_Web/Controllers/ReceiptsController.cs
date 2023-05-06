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
    public class ReceiptsController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Receipts
        public async Task<ActionResult> Index()
        {
            var receipts = db.Receipts.Include(r => r.Staff);
            return View(await receipts.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = await db.Receipts.FindAsync(id);
            receipt.ReceiptDetails=db.ReceiptsDetail.Where(x=>x.ReceiptId==receipt.ReceiptId).ToList();
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // GET: Receipts/Create
        public async Task<ActionResult> Create()
        {
            Receipt latestReceipt = (from i in db.Receipts orderby i.ReceiptId descending select i)?.FirstOrDefault();

            Receipt AddedReceipt = new Receipt()
            {
                ReceiptId = General.GenerateReceiptId(latestReceipt),
                ReceiptDate = DateTime.Now,
                StaffId = Session["user"] as string,

            };
            db.Receipts.Add(AddedReceipt);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public ActionResult AppendDetail(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = db.Receipts.Find(id);
            ViewBag.PhoneModel = new SelectList(db.PhoneModels.ToList(), "PhoneId", "PhoneName",receipt.ReceiptDetails);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AppendDetail( string id,ReceiptDetailCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Receipt latestReceipt = (from i in db.Receipts orderby i.ReceiptId descending select i)?.FirstOrDefault();

                ReceiptDetail AddedReceipt = new ReceiptDetail()
                {
                   ReceiptId=id,
                   PhoneModelId=model.PhoneModelId,
                   UnitAmmount=model.UnitAmmount,
                   Quantity=model.Quantity,
                };
                db.ReceiptsDetail.Add(AddedReceipt);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PhoneModel = new SelectList(db.PhoneModels.ToList(), "PhoneId", "PhoneName");
            return View();
        }
       

        // GET: Receipts/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt receipt = await db.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            return View(receipt);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Receipt receipt = await db.Receipts.FindAsync(id);
            db.Receipts.Remove(receipt);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
