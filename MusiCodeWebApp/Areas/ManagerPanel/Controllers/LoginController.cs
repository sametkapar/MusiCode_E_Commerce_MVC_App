using MusiCodeWebApp.Areas.ManagerPanel.Data;
using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Areas.ManagerPanel.Controllers
{
    public class LoginController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager m = db.Managers.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["manager"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.mesaj = "Kullanıcı hesabınız askıya Alınmıştır";
                    }
                }
                else
                {
                    ViewBag.mesaj = "Kullanıcı Bulunamadı";
                }
            }
            return View(model);
        }
    }
}