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
    public class AdminsController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/Admins
        public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        // GET: Admin/Admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin.Models.DataModel.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admin/Admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,Username,Password,FullName,Sex,Birthday,Phone,Email,Role,Avartar,Address")] Admin.Models.DataModel.Admin admin, HttpPostedFileBase PictureUpload1)
        {
            admin.DateCreate = DateTime.Now;
            if (ModelState.IsValid)
            {
                if (PictureUpload1 != null)
                {
                    string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImgCus/") + Dates + "_" + PictureUpload1.FileName);
                    admin.Avartar = Dates + "_" + PictureUpload1.FileName;

                    string passwordMD5 = Common.EncryptMD5(admin.Username + admin.Password);
                    admin.Password = passwordMD5;

                }
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: Admin/Admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin.Models.DataModel.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admin/Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Admin.Models.DataModel.Admin admin, HttpPostedFileBase PictureUpload1)
        {
            var ad = db.Admins.Find(admin.AdminId);
            if (PictureUpload1 != null)
            {
                string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageAvatar/") + Dates + "_" + PictureUpload1.FileName);
                ad.Avartar = Dates + "_" + PictureUpload1.FileName;
            }
            ad.FullName = admin.FullName;
            ad.Address = admin.Address;
            ad.Sex = admin.Sex;
            ad.Phone = admin.Phone;
            ad.Role = admin.Role;

            db.SaveChanges();
            return RedirectToAction("Index");

            return View(admin);
        }


        public ActionResult Changepass(int? id, string password, string cpassword)
        {
            if (password.Equals(cpassword))
            {
                var ad = db.Admins.Where(x => x.AdminId == id).FirstOrDefault();
                string passwordMD5 = Common.EncryptMD5(ad.Username + password);
                ad.Password = passwordMD5;
                db.SaveChanges();
            }

            return HttpNotFound();
        }
        // GET: Admin/Admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin.Models.DataModel.Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admin/Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin.Models.DataModel.Admin admin = db.Admins.Find(id);
            db.Admins.Remove(admin);
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
