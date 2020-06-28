using ProjectSemIII.Areas.Admin.Models.DataModel;
using ProjectSemIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Controllers
{
    public class CartController : Controller
    {
        EBookEntity db = new EBookEntity();
        private const string CartSession = "products";
        // GET: Cart
        public ActionResult ShowBasket()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart!=null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);
        }
        public ActionResult AddItem(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var book = db.Books.Find(id);
            if (book != null)
            {
                var basketmodel = new CartItem { BookId = id, Title = book.BookName, Picture = book.BookImage1, Price = book.Price-(book.Price*book.Sale/100), Quantity = 1, TotalMoney = book.Price - (book.Price * book.Sale / 100) };
                var listproduct = (List<CartItem>)Session["products"];
                var check = listproduct.SingleOrDefault(x => x.BookId == id);
                if (check != null)
                {
                    check.Quantity++;
                    check.TotalMoney = check.Price * check.Quantity;
                }
                else
                    listproduct.Add(basketmodel);
                Session["products"] = listproduct;
                return RedirectToAction("ShowBasket");
            }
            else
            {
                return HttpNotFound();

            }
        }
        

        public string UpdateCart(string id, int quantity)
        {
            var listproduct = (List<CartItem>)Session["products"];
            foreach (var item in listproduct)
            {
                if (item.BookId==id)
                {
                    item.Quantity = quantity;
                    item.TotalMoney = item.Price * quantity;

                }

            }
            Session["products"] = listproduct;
            return "/Cart/ShowBasket";
        }

        public string RemoveItem(string id)
        {
          
            var listproduct = (List<CartItem>)Session["products"];
            foreach (var item in listproduct)
            {
                if (item.BookId==id)
                {
                    listproduct.Remove(item);
                    
                }

            }
            Session["products"] = listproduct;
            return "/Cart/ShowBasket";
        }
        public ActionResult Payment()
        {
            if (Session["SessionLoginMember"] == null)
            {
                return Redirect("/Home/Login");
            }
            else
            {
                var cart = Session[CartSession];
                var list = new List<CartItem>();
                if (cart != null)
                {
                    list = (List<CartItem>)cart;

                }
                
                ViewBag.BankId = new SelectList(db.Banks, "BankId", "BankName");
                ViewBag.ShippingId = new SelectList(db.ShippingMethods, "ShippingId", "ShippingName");
                ViewBag.TransitionId = new SelectList(db.TransitionMethods, "TransitionId", "TransitionName");
                return View(list);
            }

        }

        public PartialViewResult Emoney()
        {
            var cus = db.Customers.FirstOrDefault(x=>x.Username.Equals(Session["UsernameMember"]));

            return PartialView(cus);
        }
        [HttpPost]
        public string Payment3(Order order)
        {
            if (order.TransitionId == 3)
            {
                try
                {
                    var orders = new Order();
                    order.CustomerId = int.Parse(Session["MemberId"].ToString());
                    order.TransitionId = order.TransitionId;
                    order.ShippingId = order.ShippingId;
                    order.Note = order.Note;
                    order.DateOrder = DateTime.Now;
                    order.TotalPayment = order.TotalPayment;
                    order.Status = 3;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    var id = db.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault();
                    var listproduct = (List<CartItem>)Session["products"];
                    foreach (var item in listproduct)
                    {
                        var orderdetail = new OrderDetail();
                        orderdetail.BookId = item.BookId;
                        orderdetail.OrderId = id.OrderId;
                        orderdetail.Quantity = item.Quantity;
                        orderdetail.Price = float.Parse(item.Price.ToString());
                        orderdetail.SubTotal = float.Parse((item.Price * item.Quantity).ToString());
                        db.OrderDetails.Add(orderdetail);
                    }
                    db.SaveChanges();
                    Session["products"] = null;
                    return "lưu xong";
                }
                catch (Exception)
                {
                    return "lưu thất bại";
                }
            }
            return "Không đúng kiểu";
        }
        [HttpPost]
        public ActionResult Payment(int ShippingId, int TransitionId,  string note, float totalpayment)
        {
            if (TransitionId == 1)
            {
                try
                {
                    var order = new Order();
                    order.CustomerId = int.Parse( Session["MemberId"].ToString());
                    order.TransitionId = TransitionId;
                    order.ShippingId = ShippingId;
                    order.Note = note;
                    order.DateOrder = DateTime.Now;
                    order.TotalPayment = totalpayment;
                    order.Status = 0;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    var id = db.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault();
                    var listproduct = (List<CartItem>)Session["products"];
                    foreach (var item in listproduct)
                    {
                        var orderdetail = new OrderDetail();
                        orderdetail.BookId = item.BookId;
                        orderdetail.OrderId = id.OrderId;
                        orderdetail.Quantity = item.Quantity;
                        orderdetail.Price = float.Parse(item.Price.ToString());
                        orderdetail.SubTotal = float.Parse((item.Price * item.Quantity).ToString());
                        db.OrderDetails.Add(orderdetail);
                    }
                    db.SaveChanges();
                    Session["products"] = null;
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction("Success", "Cart");
            }
           
            else
            {
               
                return HttpNotFound();
            }
            }

        public ActionResult Success()
        {

            return View();
        }
    }
       
    }
