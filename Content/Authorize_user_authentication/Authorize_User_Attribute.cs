using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management.Authorize_user_authentication
{
    public class Authorize_User_Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            if (session["Session_Email_ID"] == null)
            {
                // redirect if not logged in
                filterContext.Result = new RedirectResult("~/Login_/LoginView");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}