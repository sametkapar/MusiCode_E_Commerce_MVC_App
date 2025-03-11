using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Controllers
{
    public class MainpageController : Controller
    {
        // GET: Mainpage
        public ActionResult Index()
        {
            return View();
        }
    }
}