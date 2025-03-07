using MusiCodeWebApp.Areas.ManagerPanel.Filters;
using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusiCodeWebApp.Areas.ManagerPanel.Controllers
{
    [ManagerLoginRequiredFilter]
    public class BrandController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View(db.Brands.Where(x => x.IsActive == true).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!model.PhoneNumber.StartsWith("0"))
                    {
                        ViewBag.mesaj = "Telefon numarası 0 ile başlamalıdır";
                    }
                    else
                    {
                        db.Brands.Add(model);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Brand");
                    }
                }
                catch
                {
                    ViewBag.mesaj = "Bir hata oluştu";
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Brand b = db.Brands.Find(id);
                if (b != null)
                {
                    return View(b);
                }
            }
            return RedirectToAction("Index", "Brand");
        }
        [HttpPost]
        public ActionResult Edit(Brand model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.PhoneNumber.StartsWith("0"))
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        TempData["mesaj"] = "Marka güncelleme başarılı";
                        return RedirectToAction("Index", "Brand");
                    }
                    else
                    {
                        
                        ViewBag.mesaj = "Lütfen başında 0 olmadan giriniz";
                    }
                }
                catch
                {
                    ViewBag.mesaj = "Bir hata oluştu";
                }
            }
            return View(model);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Brand b = db.Brands.Find(id);
                b.IsDeleted = true;
                b.IsActive = false;
                db.SaveChanges();
                TempData["mesaj"] = "Marka güncelleme başarılı";

            }
            return RedirectToAction("Index", "Brand");
        }
    }
}