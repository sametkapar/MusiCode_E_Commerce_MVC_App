using MusiCodeWebApp.Areas.ManagerPanel.Data;
using MusiCodeWebApp.Filters;
using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MusiCodeWebApp.Controllers
{
    public class MemberLoginController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            if (Request.Cookies["MemberCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["MemberCookie"];
                string mail = SavedCookie.Values["mail"];
                string password = SavedCookie.Values["password"];

                Member mb = db.Members.FirstOrDefault(x => x.Mail == mail && x.Password == password);
                if (mb != null)
                {
                    if (mb.IsActive)
                    {
                        Session["MemberSession"] = mb;
                        return RedirectToAction("Index", "Register");
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
                Member mb = db.Members.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                if (mb != null)
                {
                    if (mb.IsActive)
                    {
                        if (model.RememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("MemberCookie");
                            cookie["mail"] = model.Mail;
                            cookie["password"] = model.Password;
                            cookie.Expires = DateTime.Now.AddDays(10);
                            Response.Cookies.Add(cookie);
                        }
                        Session["MemberSession"] = mb;
                        return RedirectToAction("Index", "Mainpage");
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
        public ActionResult LogOut()
        {
            Session["MemberSession"] = null;
            if (Request.Cookies["MemberCookie"] != null)
            {
                HttpCookie SavedCookie = Request.Cookies["MemberCookie"];
                SavedCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(SavedCookie);
            }

            return RedirectToAction("Index", "Mainpage");
        }
    }
}