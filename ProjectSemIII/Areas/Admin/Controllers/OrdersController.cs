using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectSemIII.Areas.Admin.Models.DataModel;

namespace ProjectSemIII.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.ShippingMethod).Include(o => o.TransitionMethod).OrderBy(x=>x.DateOrder);
            return View(orders.ToList());
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Admin/Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username");
            ViewBag.ShippingId = new SelectList(db.ShippingMethods, "ShippingId", "ShippingName");
            ViewBag.TransitionId = new SelectList(db.TransitionMethods, "TransitionId", "TransitionName");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerId,TransitionId,ShippingId,Note,DateOrder,TotalPayment,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", order.CustomerId);
            ViewBag.ShippingId = new SelectList(db.ShippingMethods, "ShippingId", "ShippingName", order.ShippingId);
            ViewBag.TransitionId = new SelectList(db.TransitionMethods, "TransitionId", "TransitionName", order.TransitionId);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", order.CustomerId);
            ViewBag.ShippingId = new SelectList(db.ShippingMethods, "ShippingId", "ShippingName", order.ShippingId);
            ViewBag.TransitionId = new SelectList(db.TransitionMethods, "TransitionId", "TransitionName", order.TransitionId);
            return View(order);
        }

        // POST: Admin/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,TransitionId,ShippingId,Note,DateOrder,TotalPayment,Status")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", order.CustomerId);
            ViewBag.ShippingId = new SelectList(db.ShippingMethods, "ShippingId", "ShippingName", order.ShippingId);
            ViewBag.TransitionId = new SelectList(db.TransitionMethods, "TransitionId", "TransitionName", order.TransitionId);
            return View(order);
        }

        // GET: Admin/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
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

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            if (order.Status == 0)
            {
                order.Status = 1;
            }else if (order.Status == 3)
            {
                order.Status = 4;
            }
            else if (order.Status == 4)
            {
                order.Status = 3;
            }
            else { order.Status = 0; }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetails = db.OrderDetails.Include(o => o.Book).Include(o => o.Order).Where(x=>x.OrderId==id);
            
            
            if (orderDetails == null)
            {
                return HttpNotFound();
            }
            
            
            return View(orderDetails.ToList());
        }
    }
}
