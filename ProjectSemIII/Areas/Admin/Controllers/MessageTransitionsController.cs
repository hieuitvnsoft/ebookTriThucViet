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
    public class MessageTransitionsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/MessageTransitions
        public ActionResult Index()
        {
            var messageTransitions = db.MessageTransitions.Include(m => m.Customer);
            return View(messageTransitions.ToList());
        }

        // GET: Admin/MessageTransitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageTransition messageTransition = db.MessageTransitions.Find(id);
            if (messageTransition == null)
            {
                return HttpNotFound();
            }
            return View(messageTransition);
        }

        // GET: Admin/MessageTransitions/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username");
            return View();
        }

        // POST: Admin/MessageTransitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankId,CustomerId,Description,Amount,AccountHoder,TimeTrans,Status")] MessageTransition messageTransition)
        {
            if (ModelState.IsValid)
            {
                db.MessageTransitions.Add(messageTransition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", messageTransition.CustomerId);
            return View(messageTransition);
        }

        // GET: Admin/MessageTransitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageTransition messageTransition = db.MessageTransitions.Find(id);
            if (messageTransition == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", messageTransition.CustomerId);
            return View(messageTransition);
        }

        // POST: Admin/MessageTransitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankId,CustomerId,Description,Amount,AccountHoder,TimeTrans,Status")] MessageTransition messageTransition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messageTransition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Username", messageTransition.CustomerId);
            return View(messageTransition);
        }

        // GET: Admin/MessageTransitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MessageTransition messageTransition = db.MessageTransitions.Find(id);
            if (messageTransition == null)
            {
                return HttpNotFound();
            }
            return View(messageTransition);
        }

        // POST: Admin/MessageTransitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MessageTransition messageTransition = db.MessageTransitions.Find(id);
            db.MessageTransitions.Remove(messageTransition);
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
