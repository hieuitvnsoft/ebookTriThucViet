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
    public class SlideshowsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/Slideshows
        public ActionResult Index()
        {
            return View(db.Slideshows.ToList());
        }

        // GET: Admin/Slideshows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // GET: Admin/Slideshows/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slideshows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image1,Image2,Image3,Image4")] Slideshow slideshow, HttpPostedFileBase PictureUpload1, HttpPostedFileBase PictureUpload2, HttpPostedFileBase PictureUpload3, HttpPostedFileBase PictureUpload4)
        {
            string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
            if (ModelState.IsValid)
            {
                if (PictureUpload1 != null)
                {
                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload1.FileName);
                    slideshow.Image1 = Dates + "_" + PictureUpload1.FileName;
                }
                if (PictureUpload2 != null)
                {
                    PictureUpload2.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload2.FileName);
                    slideshow.Image2 = DateTime.Now.ToString("ddMMyyyy-hhmmss") + "_" + PictureUpload2.FileName;
                }
                if (PictureUpload3 != null)
                {
                    PictureUpload3.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload3.FileName);
                    slideshow.Image3 = Dates + "_" + PictureUpload3.FileName;
                }
                if (PictureUpload4 != null)
                {
                    PictureUpload4.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload4.FileName);
                    slideshow.Image4 = Dates + "_" + PictureUpload4.FileName;
                }

                db.Slideshows.Add(slideshow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slideshow);
        }

        // GET: Admin/Slideshows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // POST: Admin/Slideshows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Slideshow slideshow, HttpPostedFileBase PictureUpload1, HttpPostedFileBase PictureUpload2, HttpPostedFileBase PictureUpload3, HttpPostedFileBase PictureUpload4)
        {
            if (ModelState.IsValid)
            {
                string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                if (PictureUpload1 != null)
                {
                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload1.FileName);
                    slideshow.Image1 = Dates + "_" + PictureUpload1.FileName;
                }
                if (PictureUpload2 != null)
                {
                    PictureUpload2.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload2.FileName);
                    slideshow.Image2 = Dates + "_" + PictureUpload2.FileName;
                }
                if (PictureUpload3 != null)
                {
                    PictureUpload3.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload3.FileName);
                    slideshow.Image3 = Dates + "_" + PictureUpload3.FileName;
                }
                if (PictureUpload4 != null)
                {
                    PictureUpload4.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates + "_" + PictureUpload4.FileName);
                    slideshow.Image4 = Dates + "_" + PictureUpload4.FileName;
                }
                db.Entry(slideshow).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slideshow);
        }

        // GET: Admin/Slideshows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slideshow slideshow = db.Slideshows.Find(id);
            if (slideshow == null)
            {
                return HttpNotFound();
            }
            return View(slideshow);
        }

        // POST: Admin/Slideshows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slideshow slideshow = db.Slideshows.Find(id);
            db.Slideshows.Remove(slideshow);
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
