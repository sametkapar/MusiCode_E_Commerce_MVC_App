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
            if (Request.Cookies["ManagerCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["ManagerCookie"];
                string mail = SavedCookie.Values["mail"];
                string password = SavedCookie.Values["password"];

                Manager m = db.Managers.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        Session["ManagerSession"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ManagerLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Manager m = db.Managers.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (m != null)
                {
                    if (m.IsActive)
                    {
                        if (model.RememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("ManagerCookie");
                            cookie["mail"] = model.Mail;
                            cookie["password"] = model.Password;
                            cookie.Expires = DateTime.Now.AddDays(10);
                            Response.Cookies.Add(cookie);
                        }
                        Session["ManagerSession"] = m;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.mesaj = "Kullanıcı hesabınız askıya alınmıştır";
                    }
                }
                else
                {
                    ViewBag.mesaj = "Kullanıcı bulunamadı";
                }
            }
            return View(model);
        }
    }
}