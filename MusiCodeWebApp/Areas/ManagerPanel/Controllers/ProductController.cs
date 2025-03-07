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
    public class ProductController : Controller
    {
        MusiCodeDBModel db = new MusiCodeDBModel();
        public ActionResult Index()
        {
            return View(db.Products.Where(x => x.IsDeleted == false).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        { 
            //sadece aktif kategori ve markaları gösterme??
            ViewBag.Category_ID = new SelectList(db.Categories.Where(c=>c.IsActive), "ID", "Name");
            ViewBag.Brand_ID = new SelectList(db.Brands.Where(b => b.IsActive), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Products.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Product");
                }
                catch
                {
                    ViewBag.mesaj = "Bir hata oluştu";
                }
            }
            return View(model);
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Product p = db.Products.Find(id);
                ViewBag.Category_ID = new SelectList(db.Categories, "ID", "Name",p.Category);
                ViewBag.Brand_ID = new SelectList(db.Brands, "ID", "Name",p.Brand);
                if (p != null)
                {
                    return View(p);
                }
            }
            return RedirectToAction("Index", "Product");

        }
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    TempData["mesaj"] = "Kategori güncelleme başarılı";
                    return RedirectToAction("Index", "Product");
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
                Product p = db.Products.Find(id);
                p.IsDeleted = true;
                p.IsActive = false;
                db.SaveChanges();
                TempData["mesaj"] = "Marka güncelleme başarılı";

            }
            return RedirectToAction("Index", "Product");
        }
    }
}