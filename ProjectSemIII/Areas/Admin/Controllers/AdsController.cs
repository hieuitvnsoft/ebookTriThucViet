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
    public class AdsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/Ads
        public ActionResult Index()
        {
            return View(db.Adss.ToList());
        }

        // GET: Admin/Ads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Adss.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        // GET: Admin/Ads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Ads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image,AdsLink,Description,Location,StatusOn")] Ads ads, HttpPostedFileBase PictureUpload)
        {
            if (ModelState.IsValid)
            {
                if (PictureUpload != null)

                {
                    string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                    PictureUpload.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + Dates+"_"+PictureUpload.FileName);
                    ads.Image =Dates + "_"+PictureUpload.FileName;
                }
                db.Adss.Add(ads);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ads);
        }

        // GET: Admin/Ads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Adss.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        // POST: Admin/Ads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Ads ads, HttpPostedFileBase PictureUpload)
        {
            var a = db.Adss.FirstOrDefault(x=>x.Id==ads.Id);
            if (a!=null) { 
                if (PictureUpload != null)
                {
                    PictureUpload.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAds/") + DateTime.Now.ToString("ddMMyyyy-hhmmss") + "_" + PictureUpload.FileName);
                    a.Image =DateTime.Now.ToString("ddMMyyyy-hhmmss") + "_" + PictureUpload.FileName;
}

                a.AdsLink = ads.AdsLink;
                a.Description = ads.Description;
                a.Location = ads.Location;
                a.StatusOn = ads.StatusOn;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ads);
        }

        // GET: Admin/Ads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ads ads = db.Adss.Find(id);
            if (ads == null)
            {
                return HttpNotFound();
            }
            return View(ads);
        }

        // POST: Admin/Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ads ads = db.Adss.Find(id);
            db.Adss.Remove(ads);
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
