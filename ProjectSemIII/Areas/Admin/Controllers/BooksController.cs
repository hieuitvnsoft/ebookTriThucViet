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
using PagedList;

namespace ProjectSemIII.Areas.Admin.Controllers
{
    public class BooksController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Admin/Books
        public ActionResult Index(int? pageNo, int? CateItem, string name)
        {

            List<CategoryItem> cate = new UserDao().LoadCategory();

            int pageSize = 8;//mỗi trang 3 dòng
            int pageNumber = pageNo ?? 1;//xác định số trang nào sẽ hiển thị
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            CateItem = CateItem ?? 0;
            ViewBag.CateItem = new SelectList(cate, "ID", "Name", CateItem);
            if (CateItem != 0)
            {
                if (name != null)
                    books = books.Where(x => x.CategoryId == CateItem && x.BookName.Contains(name));
                else
                    books = books.Where(x => x.CategoryId == CateItem);
            }
            else
            {
                if (name != null)
                    books = books.Where(x => x.BookName.Contains(name));
            }
            return View(books.OrderBy(x => x.BookId).ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Admin/Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "CategoryName");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName");
            List<ListItem> statusitem = new List<ListItem>
            {
                new ListItem {Value=1,Text="Hiện" },
                 new ListItem {Value=0,Text="Ẩn" }
            };
            List<ListItem> avarible = new List<ListItem>
            {
                new ListItem {Value=1,Text="Còn hàng" },
                 new ListItem {Value=0,Text="Hết hàng" }
            };
            ViewBag.StatusItem = new SelectList(statusitem, "Value", "Text");
            ViewBag.AvaribleItem = new SelectList(avarible, "Value", "Text");
            var b = db.Books.OrderByDescending(x => x.BookId).FirstOrDefault();
            if (b == null)
            {
                var book = new Book
                {
                    BookId = "B0001"
                };
                return View(book);
            }
            else
            {
                string idd = "";
                string ID = b.BookId;
                string t = ID.Substring(0, 1);
                string ints = ID.Substring(1);
                int i = int.Parse(ints);
                i += 1;
                if (i< 10)
                {
                    idd = t + "000" + i;
                }else if (i<100)
                {
                    idd = t + "00" + i;
                }
                else if(i<1000) { idd = t + "0" + i; } else { idd = t + i; }
                var book = new Book
                {
                    BookId = idd
                };
                return View(book);
            }




        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Book book, HttpPostedFileBase PictureUpload1, HttpPostedFileBase PictureUpload2, HttpPostedFileBase PictureUpload3)
        {
            if (ModelState.IsValid)
            {
                string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                if (PictureUpload1 != null)
                {
                    
                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload1.FileName);
                    book.BookImage1 = Dates + "_" + PictureUpload1.FileName;
                }
                if (PictureUpload2 != null)
                {
                    PictureUpload2.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload2.FileName);
                    book.BookImage2 = Dates + "_" + PictureUpload2.FileName;
                }
                if (PictureUpload3 != null)
                {
                    PictureUpload3.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload3.FileName);
                    book.BookImage3 = Dates + "_" + PictureUpload3.FileName;
                }

                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
            List<ListItem> statusitem = new List<ListItem>
            {
                new ListItem {Value=1,Text="Hiện" },
                 new ListItem {Value=0,Text="Ẩn" }
            };
            List<ListItem> avarible = new List<ListItem>
            {
                new ListItem {Value=1,Text="Còn hàng" },
                 new ListItem {Value=0,Text="Hết hàng" }
            };
            ViewBag.StatusItem = new SelectList(statusitem, "Value", "Text", book.StatusOn);
            ViewBag.AvaribleItem = new SelectList(avarible, "Value", "Text", book.StatusAvarible);
            return View(book);
        }

        // GET: Admin/Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "CategoryName", book.CategoryId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
            List<ListItem> statusitem = new List<ListItem>
            {
                new ListItem {Value=1,Text="Hiện" },
                 new ListItem {Value=0,Text="Ẩn" }
            };
            List<ListItem> avarible = new List<ListItem>
            {
                new ListItem {Value=1,Text="Còn hàng" },
                 new ListItem {Value=0,Text="Hết hàng" }
            };
            ViewBag.StatusItem = new SelectList(statusitem, "Value", "Text", book.StatusOn);
            ViewBag.AvaribleItem = new SelectList(avarible, "Value", "Text", book.StatusAvarible);
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Book book, HttpPostedFileBase PictureUpload1, HttpPostedFileBase PictureUpload2, HttpPostedFileBase PictureUpload3)
        {
            var bok = db.Books.FirstOrDefault(x=>x.BookId==book.BookId);
            if (bok!=null )
            {
                string Dates = DateTime.Now.ToString("ddMMyyyy-hhmmss");
                if (PictureUpload1 == null)
                {

                }
                else
                {
                    PictureUpload1.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload1.FileName);
                    bok.BookImage1 = Dates + "_" + PictureUpload1.FileName;

                }

                if (PictureUpload2 == null)
                {

                }
                else
                {
                    PictureUpload2.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload2.FileName);
                    bok.BookImage2 = Dates + "_" + PictureUpload2.FileName;
                }
                if (PictureUpload3 == null)
                {

                }
                else
                {
                    PictureUpload3.SaveAs(Server.MapPath("~/Areas/Admin/Content/ImageBook/") + Dates + "_" + PictureUpload3.FileName);
                    bok.BookImage3 = Dates + "_" + PictureUpload3.FileName;
                }
                bok.BookName = book.BookName;
                bok.CategoryId = book.CategoryId;
                bok.PublisherId = book.PublisherId;
                bok.AuthorId = book.AuthorId;
                bok.PublishingYear = book.PublishingYear;
                bok.Sale = book.Sale;
                bok.Price = book.Price;
                bok.Description = book.Description;
                bok.StatusAvarible = book.StatusAvarible;
                bok.StatusOn = book.StatusOn;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName", book.AuthorId);
                ViewBag.CategoryId = new SelectList(db.Categorys, "CategoryId", "CategoryName", book.CategoryId);
                ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "PublisherName", book.PublisherId);
                List<ListItem> statusitem = new List<ListItem>
            {
                new ListItem {Value=1,Text="Hiện" },
                 new ListItem {Value=0,Text="Ẩn" }
            };
                List<ListItem> avarible = new List<ListItem>
            {
                new ListItem {Value=1,Text="Còn hàng" },
                 new ListItem {Value=0,Text="Hết hàng" }
            };
                ViewBag.StatusItem = new SelectList(statusitem, "Value", "Text", book.StatusOn);
                ViewBag.AvaribleItem = new SelectList(avarible, "Value", "Text", book.StatusAvarible);
                return View(book);
            }
        }
                
            
           

        // GET: Admin/Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
        //public void SetAvarible(int? selected)
        //{
        //    var list = new List<KeyValuePair<string, int>>();
        //    list.Add(new KeyValuePair<string, int>("Bật", 1));
        //    list.Add(new KeyValuePair<string, int>("Tắt", 0));
        //    ViewBag.Avarible = new SelectListItem("");
        //}
        //public void SetStatus(int? selected)
        //{

        //}
    }
}
