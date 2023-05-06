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
using Microsoft.Extensions.Options;

namespace MobilePhoneDistributor_Web.Controllers
{
    public class OrdersController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            string id;
            if (Session["user"]==null)
            {
                return RedirectToAction("Login", "Agents", null);
                
            }
            if (Session["role"] as string == "Staff")
            {
                return View(db.Orders.ToList());
            }
            id = Session["user"] as string;
            return View(db.Orders.ToList().Where(i=>i.AgentId==id));
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            order.OrderDetails = db.OrdersDetail.Where(i => i.OrderId == id).Include(o => o.PhoneModel).ToList();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var cart = Session["cart"] as Cart;
            if (cart==null || cart.GetItems().Count()==0)
            {
                return RedirectToAction("Index", "PhoneModels", null);
            }
            var options = new List<SelectListItem>
            {
                new SelectListItem { Value = "COD", Text = "Cash On Delivery" },
                new SelectListItem { Value = "VNPAY", Text = "VnPay" },
           
            };
            ViewBag.Options = new SelectList(options,"Value","Text","COD");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PaymentMethod")] Order order)
        {
            
            Order IdLastest;
            if ((from i in db.Orders orderby i.OrderId descending select i)?.FirstOrDefault() == null)
            {
                IdLastest = null;
            }
            else
            {
                IdLastest = (from i in db.Orders orderby i.OrderId descending select i)?.FirstOrDefault();
            }
            string id = General.GenerateOrdertId(IdLastest);
            order.OrderId = id;
            order.OrderDate = DateTime.Now;
            order.AgentId = Session["user"] as string;
            order.OrderStatus = "On Processing";
            order.PaymentStatus = "Not Payed";
            
            if (order.PaymentMethod != null)
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
            }
            else
            {
                return View();
            }
            var cart = Session["cart"] as Cart;
            foreach ( var item in cart.GetItems())
            {
                var detail = new OrderDetail
                {
                    OrderId = id,
                    PhoneModelId = item.PhoneModelId,
                    Quantity = item.Quantity,
                };
                db.OrdersDetail.Add(detail);
                db.SaveChanges();
            }
            Session["cart"] = null;
            return RedirectToAction("Index");
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Update(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            var options = new List<SelectListItem>
            {
                new SelectListItem { Value = "Payed", Text = "Payed" },
                new SelectListItem { Value = "Not Payed", Text = "Not Payed" },

            };
            // Last option for agent confirmation if still has times
            var options1 = new List<SelectListItem>
            {
                new SelectListItem { Value = "On Processing", Text = "On Processing" },
                new SelectListItem { Value = "Confirmed", Text = "Confirmed" },
                new SelectListItem { Value = "On Delivering", Text = "On Delivering" },
                new SelectListItem { Value = "Delivered", Text = "Delivered" },
            };
            ViewBag.Options = new SelectList(options, "Value", "Text", "Not Payed");
            ViewBag.Options2 = new SelectList(options1, "Value", "Text", "On Processing");
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(string id,[Bind(Include = "OrderStatus,PaymentStatus")] Order order)
        {
            if (order.OrderStatus != null || order.PaymentStatus !=null)
            {
                Order order1 = await  db.Orders.FindAsync(id);
                order1.OrderStatus = order.OrderStatus;
                order1.PaymentStatus = order.PaymentStatus;
                if (order1.OrderStatus == "On Delivering")
                {
                    if (await db.DeliveryNotes.AnyAsync(p => p.OrderId == id))
                    {
                        return RedirectToAction("Index");
                    }
                    DeliveryNote deliveryNote = new DeliveryNote()
                    {
                        OrderId = id,
                        DeliveryDate = DateTime.Now,
                        DeliveryNoteId = id.Substring(0, 6) + "DN" + id.Substring(7),
                    };
                    db.DeliveryNotes.Add(deliveryNote);
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var options = new List<SelectListItem>
            {
                new SelectListItem { Value = "Payed", Text = "Payed" },
                new SelectListItem { Value = "Not Payed", Text = "Not Payed" },

            };
            ViewBag.Options = new SelectList(options, "Value", "Text", "Not Payed");
            // Last option for agent confirmation if still has times
            var options1 = new List<SelectListItem>
            {
                new SelectListItem { Value = "On Processing", Text = "On Processing" },
                new SelectListItem { Value = "Confirmed", Text = "Confirmed" },
                new SelectListItem { Value = "On Delivering", Text = "On Delivering" },
                new SelectListItem { Value = "Delivered", Text = "Delivered" },
            };
            ViewBag.Options2 = new SelectList(options1, "Value", "Text", "On Processing");
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "User", null);
            }
            string role = Session["role"] as string;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (role == "Agent" && order.OrderStatus != "On Processing")
            {
                return RedirectToAction("Index");
            }
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
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
