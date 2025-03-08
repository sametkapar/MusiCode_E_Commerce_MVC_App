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
        // GET: ManagerPanel/Brand
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View(db.Brands.Where(x => x.IsDeleted == false).ToList());
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
                    db.Brands.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Brand");
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
                Brand c = db.Brands.Find(id);
                if (c != null)
                {
                    return View(c);
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
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    TempData["mesaj"] = "Kategori güncelleme başarılı";
                    return RedirectToAction("Index", "Brand");
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
                Brand c = db.Brands.Find(id);
                if (c != null)
                {
                    c.IsDeleted = true;
                    c.IsActive = false;
                    db.SaveChanges();
                    TempData["mesaj"] = "Marka silme işlemi başarılı";
                }
            }
            return RedirectToAction("Index", "Brand");
        }
    }
}