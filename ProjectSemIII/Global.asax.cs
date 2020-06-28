using ProjectSemIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProjectSemIII
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {
          
            Session["AdminId"] = null;
            Session["UsernameAdmin"] = null;
            Session["FullNameAdmin"] = null;
            Session["RoleAdmin"] = null;
            Session["AvatarAdmin"] = null;

            Session["SessionLoginMember"] = null;
            Session["MemberId"] = null;
            Session["FullNameMember"] = null;
            Session["UsernameMember"] = null;
            Session["AvatarMember"] = null;

            Session["products"] = new List<CartItem>();
        }
    }
}
