using System;
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
    public class DeliveryNotesController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: DeliveryNotes
        public async Task<ActionResult> Index()
        {
            var deliveryNotes = db.DeliveryNotes.Include(d => d.Order);
            return View(await deliveryNotes.ToListAsync());
        }

        // GET: DeliveryNotes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = await db.DeliveryNotes.FindAsync(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            deliveryNote.Order=await db.Orders.FindAsync(deliveryNote.OrderId);
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryNote deliveryNote = await db.DeliveryNotes.FindAsync(id);
            if (deliveryNote == null)
            {
                return HttpNotFound();
            }
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            DeliveryNote deliveryNote = await db.DeliveryNotes.FindAsync(id);
            Order order = await db.Orders.FindAsync(deliveryNote.OrderId);
            order.OrderStatus = "On Processing";
            db.DeliveryNotes.Remove(deliveryNote);
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
