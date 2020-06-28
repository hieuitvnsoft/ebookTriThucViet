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
    public class TransitionMethodsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/TransitionMethods
        public ActionResult Index()
        {
            return View(db.TransitionMethods.ToList());
        }

        // GET: Admin/TransitionMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransitionMethod transitionMethod = db.TransitionMethods.Find(id);
            if (transitionMethod == null)
            {
                return HttpNotFound();
            }
            return View(transitionMethod);
        }

        // GET: Admin/TransitionMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TransitionMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransitionId,TransitionName,Description")] TransitionMethod transitionMethod)
        {
            if (ModelState.IsValid)
            {
                db.TransitionMethods.Add(transitionMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transitionMethod);
        }

        // GET: Admin/TransitionMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransitionMethod transitionMethod = db.TransitionMethods.Find(id);
            if (transitionMethod == null)
            {
                return HttpNotFound();
            }
            return View(transitionMethod);
        }

        // POST: Admin/TransitionMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransitionId,TransitionName,Description")] TransitionMethod transitionMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transitionMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transitionMethod);
        }

        // GET: Admin/TransitionMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransitionMethod transitionMethod = db.TransitionMethods.Find(id);
            if (transitionMethod == null)
            {
                return HttpNotFound();
            }
            return View(transitionMethod);
        }

        // POST: Admin/TransitionMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransitionMethod transitionMethod = db.TransitionMethods.Find(id);
            db.TransitionMethods.Remove(transitionMethod);
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
