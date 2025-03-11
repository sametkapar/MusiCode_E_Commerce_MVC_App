using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using MusiCodeWebApp.Models;

namespace MusiCodeWebApp.Filters
{
    public class MemberLoginRequiredFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        MusiCodeDBModel db = new MusiCodeDBModel();

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["MemberSession"])))
            {
                if (filterContext.HttpContext.Request.Cookies["MemberCookie"] != null)
                {
                    HttpCookie SavedCookie = filterContext.HttpContext.Request.Cookies["MemberCookie"];
                    string mail = SavedCookie.Values["mail"];
                    string password = SavedCookie.Values["password"];
                    Member mb = db.Members.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                    if (mb != null)
                    {
                        if (mb.IsActive)
                        {
                            filterContext.HttpContext.Session["MemberSession"] = mb;
                        }
                    }
                }
                else
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Mainpage/Index");
            }
        }
    }
}