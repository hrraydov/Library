using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Filters
{
    public class IsAuthenticatedAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = filterContext.HttpContext.Session;
            var isAuthenticated = session["isAuthenticated"];
            if (isAuthenticated != null && (bool)isAuthenticated)
            {
                return;
            }
            filterContext.Result = new RedirectResult("/account/login");
        }
    }
}