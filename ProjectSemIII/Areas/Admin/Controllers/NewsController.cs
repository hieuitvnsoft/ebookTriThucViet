using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectSemIII.Areas.Admin.Models.DataModel;
using ProjectSemIII.Areas.Admin.Models.BussinessModel;

namespace ProjectSemIII.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class NewsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/News
        public ActionResult Index()
        {
            var newss = db.Newss.Include(n => n.Admin);
            return View(newss.ToList());
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newss.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            int id = int.Parse(Session["AdminId"].ToString());
            var ad = db.Admins.Where(x => x.AdminId == id);
            ViewBag.AdminId = new SelectList(ad, "AdminId", "Username");
            return View();
        }

        // POST: Admin/News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news, HttpPostedFileBase PictureUpload1)
        {
            if (ModelState.IsValid)
            {
                string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                if (PictureUpload1 != null)
                {

                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImgNew/") + Dates + "_" + PictureUpload1.FileName);
                    news.Image = Dates + "_" + PictureUpload1.FileName;
                }
                db.Newss.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdminId = new SelectList(db.Admins, "AdminId", "Username", news.AdminId);
            return View(news);
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newss.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdminId = new SelectList(db.Admins, "AdminId", "Username", news.AdminId);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tittle,Desciption,Content,Image,Keyword,DateWirite,AdminId")] News news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdminId = new SelectList(db.Admins, "AdminId", "Username", news.AdminId);
            return View(news);
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.Newss.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: Admin/News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.Newss.Find(id);
            db.Newss.Remove(news);
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
