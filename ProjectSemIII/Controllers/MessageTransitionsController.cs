using ProjectSemIII.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Controllers
{
    public class MessageTransitionsController : Controller
    {
        EBookEntity db = new EBookEntity(); 
        [HttpPost]
        public string CreateMess(MessageTransition mess)
        {
            try
            {
                MessageTransition ms = new MessageTransition();
                ms.CustomerId = int.Parse(Session["MemberId"].ToString());
                ms.BankId = mess.BankId;
                ms.Description = "Bạn nhận được chuyển khoản ngân hàng";
                ms.Amount = mess.Amount;
                ms.AccountHoder = 0;
                ms.TimeTrans = DateTime.Now;
                ms.Status = false;
                db.MessageTransitions.Add(ms);
                db.SaveChanges();
                return "Ok";
            }
            catch (Exception)
            {

                return "False";
            }
            
            
        }
    }
}