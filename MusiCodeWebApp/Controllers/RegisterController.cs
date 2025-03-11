using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Controllers
{
    public class RegisterController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Member model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = db.Members.FirstOrDefault(x => x.Mail == model.Mail);
                    if (user != null)
                    {
                        ViewBag.Error = "Bu mail kullanılmaktadır";
                        return View(model);
                    }
                    model.RegistrationTime = DateTime.Now;
                    model.LastLoginTime = DateTime.Now;
                    model.IsActive = true;
                    model.IsDeleted = false;
                    db.Members.Add(model);
                    db.SaveChanges();
                    TempData["Success"] = "Kullanıcı kaydı başarı ile yapılmıştır";
                    return RedirectToAction("Index", "MemberLogin");


                }
                catch
                {
                    ViewBag.Error = "Bir hata oluştu.";
                }
            }
            return View(model);
        }
    }
}