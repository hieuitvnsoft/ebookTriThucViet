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
    public class ListBankEBooksController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/ListBankEBooks
        public ActionResult Index()
        {
            var listBankEBook = db.ListBankEBook.Include(l => l.Bank);
            return View(listBankEBook.ToList());
        }

        // GET: Admin/ListBankEBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListBankEBook listBankEBook = db.ListBankEBook.Find(id);
            if (listBankEBook == null)
            {
                return HttpNotFound();
            }
            return View(listBankEBook);
        }

        // GET: Admin/ListBankEBooks/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName");
            return View();
        }

        // POST: Admin/ListBankEBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BankId,AcBank")] ListBankEBook listBankEBook)
        {
            if (ModelState.IsValid)
            {
                db.ListBankEBook.Add(listBankEBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName", listBankEBook.BankId);
            return View(listBankEBook);
        }

        // GET: Admin/ListBankEBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListBankEBook listBankEBook = db.ListBankEBook.Find(id);
            if (listBankEBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName", listBankEBook.BankId);
            return View(listBankEBook);
        }

        // POST: Admin/ListBankEBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BankId,AcBank")] ListBankEBook listBankEBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listBankEBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName", listBankEBook.BankId);
            return View(listBankEBook);
        }

        // GET: Admin/ListBankEBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListBankEBook listBankEBook = db.ListBankEBook.Find(id);
            if (listBankEBook == null)
            {
                return HttpNotFound();
            }
            return View(listBankEBook);
        }

        // POST: Admin/ListBankEBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListBankEBook listBankEBook = db.ListBankEBook.Find(id);
            db.ListBankEBook.Remove(listBankEBook);
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
