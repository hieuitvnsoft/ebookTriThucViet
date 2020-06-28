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
    public class ShippingMethodsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/ShippingMethods
        public ActionResult Index()
        {
            return View(db.ShippingMethods.ToList());
        }

        // GET: Admin/ShippingMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethods.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShippingMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingId,ShippingName,Cost,Description")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                db.ShippingMethods.Add(shippingMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethods.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingId,ShippingName,Cost,Description")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = db.ShippingMethods.Find(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingMethod shippingMethod = db.ShippingMethods.Find(id);
            db.ShippingMethods.Remove(shippingMethod);
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
    }
}
