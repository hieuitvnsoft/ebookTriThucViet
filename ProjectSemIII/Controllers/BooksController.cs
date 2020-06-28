using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectSemIII.Areas.Admin.Models.DataModel;
using ProjectSemIII.Models;

namespace ProjectSemIII.Controllers
{
    public class BooksController : Controller
    {
        private EBookEntity db = new EBookEntity();

        // GET: Books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.Category).Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            var Ca = db.Categorys.FirstOrDefault(x=>x.CategoryId==book.CategoryId);
            var Au = db.Authors.FirstOrDefault(x => x.AuthorId == book.AuthorId);
            var Pb = db.Publishers.FirstOrDefault(x => x.PublisherId == book.PublisherId);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                BookDetailView a = new BookDetailView();
                a.BookId = book.BookId;
                a.Category = Ca.CategoryName;
                a.AuthorName = Au.AuthorName;
                a.PublisherName = Pb.PublisherName;
                a.BookName = book.BookName;
                a.PublishingYear = book.PublishingYear;
                a.Price = book.Price;
                a.Sale = book.Sale;
                a.Descriptions = book.Description;
                a.BookImage1 = book.BookImage1;
                a.BookImage2 = book.BookImage2;
                a.BookImage3 = book.BookImage3;
                a.StatusVarible = book.StatusAvarible;
                a.StatusOn = book.StatusOn;

                return View(a);
            }
            
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       public ActionResult Category(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            else
            {
                var cate = db.Books.Where(x => x.CategoryId == id && x.StatusOn == 1).ToList();
                ViewBag.CategoryId = db.Categorys.FirstOrDefault(x=>x.CategoryId==id);
                return View(cate);
            }

        }

        public ActionResult Publisher(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var cate = db.Books.Where(x => x.PublisherId == id && x.StatusOn == 1).ToList();
                ViewBag.PublisherId = db.Publishers.FirstOrDefault(x => x.PublisherId == id);
                return View(cate);
            }

        }
        public ActionResult Author(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var cate = db.Books.Where(x => x.AuthorId == id && x.StatusOn == 1).ToList();
                ViewBag.AuthorId = db.Authors.FirstOrDefault(x => x.AuthorId == id);
                return View(cate);
            }

        }
        public ActionResult Sale()
        {
                var book = db.Books.Where(x => x.Sale >=1).OrderBy(x=>x.Sale).ToList();
                return View(book);
            
        }
        public ActionResult NewsView()
        {
            var n = db.Newss.OrderBy(x => x.Id).ToList();
            return View(n);
        }
        public ActionResult ViewNew(int? id)
        {


            if (id == null)
            {
                return HttpNotFound();
            }
            var n = db.Newss.Where(x => x.Id == id).FirstOrDefault();
            var ad = db.Admins.Where(x => x.AdminId == n.AdminId).FirstOrDefault();
            ViewBag.ad = ad;
            return View(n);
        }
    }
}
