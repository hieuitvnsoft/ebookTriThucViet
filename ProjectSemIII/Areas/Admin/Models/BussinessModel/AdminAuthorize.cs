using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectSemIII.Areas.Admin.Models.BussinessModel
{
    public class AdminAuthorize: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session["RoleAdmin"] ==null)
            {
                filterContext.Result = new RedirectResult("/Admin/Home/Login");
            }
        }
    }
}