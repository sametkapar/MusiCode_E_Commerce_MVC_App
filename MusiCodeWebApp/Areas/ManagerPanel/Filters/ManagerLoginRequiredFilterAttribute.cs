using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MusiCodeWebApp.Areas.ManagerPanel.Filters
{
    public class ManagerLoginRequiredFilterAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Kontrol işlemlerimizi bu alanda yapacağız
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["ManagerSession"])))
            {
                if (filterContext.HttpContext.Request.Cookies["ManagerCookie"] != null)
                {
                    HttpCookie SavedCookie = filterContext.HttpContext.Request.Cookies["ManagerCookie"];
                    string mail = SavedCookie.Values["mail"];
                    string password = SavedCookie.Values["password"];
                    Manager m = db.Managers.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                    if (m != null)
                    {
                        if (m.IsActive)
                        {
                            filterContext.HttpContext.Session["ManagerSession"] = m;
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
            //Kontrol sonrasındaki yönlendirme gibi davranışları bu alanda belirleyeceğiz
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/ManagerPanel/Login/Index");
            }
        }
    }
}