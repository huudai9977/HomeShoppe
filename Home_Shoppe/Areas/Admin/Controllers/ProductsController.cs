using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Home_Shoppe.Models;
using PagedList;

namespace Home_Shoppe.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {

        private HomeShopDbContext db = new HomeShopDbContext();
        [Authorize(Roles = "Admin,Maganer,Employee")]
        // GET: Admin/Products
        public ActionResult Index(int page = 1, int pagesize = 12)
        {
            var p = db.Products.SqlQuery("Select * from Product ").ToPagedList(page, pagesize);
            return View(p);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "NameCategory");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,IdCategory,NameProduct,Price,ProductDetails,Description,Status,New,Views,Sold,Image1,Image2,Image3,Image4,Image5,Image6")] Product product,HttpPostedFileBase img)
        {
            long count = db.Products.LongCount();
            string id = "P" + count.ToString("00000");
            product.IdProduct = id;
            product.Status = 0;
            product.Sold = 0;
            product.New = "N'New'";
            if (ModelState.IsValid)
            {

                HttpPostedFileBase file = Request.Files[0];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image1 = _FileName;
                }
                file = Request.Files[1];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image2 = _FileName;
                }
                file = Request.Files[2];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image3 = _FileName;
                }
                file = Request.Files[3];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image4 = _FileName;
                }
                file = Request.Files[4];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image5 = _FileName;
                }
                file = Request.Files[5];
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Asset/data/"), _FileName);
                    file.SaveAs(_path);
                    product.Image6 = _FileName;
                }
                
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "NameCategory", product.IdCategory);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "NameCategory", product.IdCategory);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,IdCategory,NameProduct,Price,ProductDetails,Description,Status,New,Views,Sold,Image1,Image2,Image3,Image4,Image5,Image6")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategory = new SelectList(db.Categories, "IdCategory", "NameCategory", product.IdCategory);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
