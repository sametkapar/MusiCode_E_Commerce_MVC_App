using MusiCodeWebApp.Areas.ManagerPanel.Filters;
using MusiCodeWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            return View(db.Products.Where(x=> x.IsDeleted == false).ToList());
        }

      
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name");
            ViewBag.Brand_ID = new SelectList(db.Brands.Where(x => x.IsDeleted == false), "ID", "Name");
            return View();
        }

        
        [HttpPost]
        public ActionResult Create(Product Model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isvalidimage = true;
                    if (image != null)
                    {
                        FileInfo fi = new FileInfo(image.FileName);
                        string extension = fi.Extension;
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            string name = Guid.NewGuid().ToString() + extension;
                            Model.Image = name;
                            image.SaveAs(Server.MapPath("~/Assets/ProductImages/" + name));
                        }
                        else
                        {
                            isvalidimage = false;
                            ViewBag.mesaj = "Resim uzantısı .jpg, .jpeg, .png olabilir";
                        }
                    }
                    else
                    {
                        Model.Image = "none.jpg";
                    }
                    if (isvalidimage)
                    {
                        Model.CreationTime = DateTime.Now;
                        db.Products.Add(Model);
                        db.SaveChanges();
                        TempData["mesaj"] = "Ürün ekleme başarılı";
                        return RedirectToAction("Index", "Product");
                    }
                }
                catch
                {
                    ViewBag.mesaj = "Ürün eklenirken bir hata oluştu";
                }
            }
            ViewBag.Category_ID = new SelectList(db.Categories.Where(x => x.IsDeleted == false), "ID", "Name");
            ViewBag.Brand_ID = new SelectList(db.Brands.Where(x => x.IsDeleted == false), "ID", "Name");
            return View(Model);
        }

        // GET: ManagerPanel/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ManagerPanel/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerPanel/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
