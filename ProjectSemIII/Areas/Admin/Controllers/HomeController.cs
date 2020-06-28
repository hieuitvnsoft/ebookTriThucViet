
using ProjectSemIII.Areas.Admin.Models.BussinessModel;
using ProjectSemIII.Areas.Admin.Models.DataModel;
using System.Linq;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        EBookEntity db = new EBookEntity();

        // GET: Admin/Home

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Home/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Home/Create
        [HttpPost]

        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        [AdminAuthorize]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Admin/Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Home/Delete/5
        [HttpPost]
        [AdminAuthorize]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passwordMD5 = Common.EncryptMD5(username + password);

            var account = db.Admins.SingleOrDefault(x => x.Username == username);
            if (account != null)
            {
                if (account.Password.Equals(passwordMD5))
                {

                    Session["SessionLoginAdmin"] = username;
                    Session["AdminId"] = account.AdminId;
                    Session["UsernameAdmin"] = account.Username;
                    Session["RoleAdmin"] = account.Role;
                    Session["AvatarAdmin"] = account.Avartar;
                    Session["FullNameAdmin"] = account.FullName;
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
                TempData["msg"] = "<div class='alert-warning'>Bạn định hack chúng tôi à?</div>";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["SessionLoginAdmin"] = null;
            Session["AdminId"] = null;
            Session["UsernameAdmin"] = null;
            Session["RoleAdmin"] = null;
            Session["AvatarAdmin"] = null;
            Session["FullNameAdmin"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            var acc = db.Admins.FirstOrDefault(x => x.Email == email);
            if (acc != null)
            {
                string uid = UserDao.GenUID();
                acc.UIDcode = uid;
                db.SaveChanges();
                var url = @"http://localhost:50168/Admin/Home/RsPass?email=" + email + "&UIDcode=" + uid;
                var link = @"<div> Chúng tôi vừa nhận được yêu cầu lấy lại mật khẩu trên trang Admin của EBook-Tri Thức Việt<br/><b>Nếu không phải là bạn hãy bỏ qua email này!</b> <br/><br/><br/>Nếu là bạn hãy nhấn vào <a href=" + url + ">Đây</a>  để thay đổi mật khẩu</div>";
                SendMail.SendEmail(email, "hieuitvnsoft@gmail.com", link);

                TempData["msg"] = "<div class='alert-success'>Hãy kiểm tra email để lấy lại mật khẩu!</div>";
                return View("Login");
            }
            else
            {
                TempData["msg"] = "<div class='alert-danger'>Email đăng ký không tồn tại!</div>";
                return View();
            }


        }
        public ActionResult RsPass(string email, string uid)
        {
            var ad = db.Admins.FirstOrDefault(x => x.Email == email && x.UIDcode == uid);

            return View(ad);
        }

        [HttpPost]
        public ActionResult RsPass(string email, string password, string confirm_password)
        {
            var acc = db.Admins.FirstOrDefault(x => x.Email == email);

            acc.Password = Common.EncryptMD5(acc.Username + password);
            acc.UIDcode = "";
            db.SaveChanges();
            return View("Login");



        }
        public PartialViewResult Order()
        {

            var Ord = db.Orders.Where(x=>x.Status==0);

            return PartialView(Ord.ToList());
        }
        public PartialViewResult Order1()
        {

            var Ord = db.Orders.Where(x => x.Status == 3);

            return PartialView(Ord.ToList());
        }
    }
}

