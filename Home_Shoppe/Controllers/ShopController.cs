﻿using Home_Shoppe.Models;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Home_Shoppe.Controllers
{
    public class ShopController : Controller
    {
        public HomeShopDbContext db = new HomeShopDbContext();

        // GET: Shop
        public ActionResult Index()
        {
            
            return View();
        }
        //GET : data
        public static IEnumerable<Category> ListCategories()
        {
            var dba= new HomeShopDbContext();
            var c = dba.Categories.SqlQuery("Select * from Category ");
            return c;
        }
        public static IEnumerable<Product> NewProduct()
        {
            var dba = new HomeShopDbContext();
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product ORDER BY IdProduct DESC");
            return c;
        }

        public static IEnumerable<Product> RelatedProduct(string id)
        {
            var dba = new HomeShopDbContext();
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product where IdCategory='" + id + "'"+" ORDER BY Views DESC");
            return c;
        }

        public static IEnumerable<Product> FeatureProduct()
        {
            var dba = new HomeShopDbContext();
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product ORDER BY Views DESC");
            return c;
        }
        // GET:  all Product
        public ActionResult AllProduct(int page=1,int pagesize=12 )
        {
            var p = db.Products.SqlQuery("Select * from Product ").ToPagedList(page,pagesize);
            return View(p);
        }
        //GET: Data
        public ActionResult Category(string id,int page = 1, int pagesize = 12)
        {
            var p = db.Products.SqlQuery("Select * from Product where IdCategory='"+id+"'").ToPagedList(page, pagesize);
            ViewBag.NameCategory = db.Categories.SingleOrDefault(a => a.IdCategory == id).NameCategory;
            return View(p);
        }

        // GET: Shop/Details/5
        public ActionResult Details(string id)
        {
            
            var view = db.Products.SingleOrDefault(a => a.IdProduct == id );
            
            return View(view);
        }

        // GET: Shop/About
        public ActionResult About()
        {
            return View();
        }

        // GET: Shop/Delivery
        public ActionResult Delivery()
        {
            return View();
        }

        // GET: Shop/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Shop/News
        public ActionResult News()
        {
            return View();
        }

        
    }
}
