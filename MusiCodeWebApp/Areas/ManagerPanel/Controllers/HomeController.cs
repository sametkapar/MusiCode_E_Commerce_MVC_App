using MusiCodeWebApp.Areas.ManagerPanel.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerLoginRequiredFilter]
    public class HomeController : Controller
    {
        //[ManagerLoginRequiredFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}