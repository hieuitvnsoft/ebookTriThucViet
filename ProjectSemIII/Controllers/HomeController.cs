using PagedList;
using ProjectSemIII.Areas.Admin.Models.BussinessModel;
using ProjectSemIII.Areas.Admin.Models.DataModel;
using ProjectSemIII.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Controllers
{
    public class HomeController : Controller
    {
        EBookEntity db = new EBookEntity();

        public ActionResult Index(int? pageNo)
        {
            int pageSize = 12;//mỗi trang 3 dòng
            int pageNumber = pageNo ?? 1;//xác định số trang nào sẽ hiển thị
            var books = db.Books.Where(x=>x.StatusOn==1);

            return View(books.OrderBy(x => x.BookId).ToPagedList(pageNumber, pageSize));
            
        }

        public ActionResult SlideShow()
        {
            var slideShow = db.Slideshows.FirstOrDefault();

            return PartialView(slideShow);
        }

        public ActionResult Ads()
        {
            var ads = db.Adss.Where(x => x.Location == 1).ToList();

            return PartialView(ads);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Category()
        {
            var cate = db.Categorys.ToList();
            return PartialView(cate);

        }
        public ActionResult Author()
        {
            var au = db.Authors.ToList();
            return PartialView(au);

        }
        public ActionResult Publisher()
        {
            var pb = db.Publishers.ToList();
            return PartialView(pb);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Details(string idBook)
        {
            if (idBook == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(idBook);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passwordMD5 = Common.EncryptMD5(username + password);

            var account = db.Customers.SingleOrDefault(x => x.Username == username);
            if (account != null)
            {
                if (account.Password == passwordMD5)
                {


                    Session["SessionLoginMember"] = username;
                    Session["MemberId"] = account.CustomerId;
                    Session["UsernameMember"] = account.Username;
                    Session["AvatarMember"] = account.Avartar;
                    Session["FullNameMember"] = account.FullName;
                    TempData["msg"] = "<div class='alert-success'>Đăng nhập thành công</div>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["msg"] = "<div class='alert-danger'>Đăng nhập thất bại, kiểm tra lại tài khoản mật khẩu</div>";
                    return View();
                }
            }
            else
            {
                TempData["msg"] = "<div class='alert-warning'>Tài khoản mật khẩu không đúng xin kiểm tra lại</div>";
                return View();
            }
        }
        public ActionResult Register()
        {
            ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName");
            return View();
        }
        [HttpPost]
        public ActionResult Register(string username, string password,string fullname,bool? sex, DateTime birthday, string phone, string email, string add)
        {
            if (sex==null)
            {
                sex = false;
            }
            var cus = db.Customers.FirstOrDefault(x=>x.Username.Equals(username));
            if (cus==null)
            {
                Customer s = new Customer();

                s.Username = username;
                string passwordMD5 = Common.EncryptMD5(username+ password);
                s.Password = passwordMD5;
                s.EMoney = 0;
                s.FullName = fullname;
                s.Sex = sex.Value;
                s.Birthday = birthday;
                s.Phone = phone;
                s.Email = email;
                s.Address = add;
                db.Customers.Add(s);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            TempData["msg"] = "<div class='alert-warning'>Đăng ký thất bại, xin nhập lại thông tin</div>";
            return View();
        }

        public PartialViewResult View()
        {
            var cart = Session["products"];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return PartialView(list);
        }

        
    }

}
