using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Home_Shoppe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Home_Shoppe.Controllers
{
    public class CartsController : Controller
    {
        private HomeShopDbContext db = new HomeShopDbContext();


        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.SqlQuery("Select * from Carts where UserID='" + User.Identity.GetUserName() + "' and IdBill IS NULL");
            ViewBag.QuantityProduct = carts.Count();
            ViewBag.TotalPrice = carts.Sum(x => x.Total);
            return View(carts.ToList());
        }

        // POST: Carts/Index
        [HttpPost, ActionName("Index")]
        public ActionResult Index(string IdCart, string Color,int Quantity,string btn)
        {
            
            var cart = db.Carts.Find(IdCart);
            
            if (ModelState.IsValid)
            {
                if (btn == "Update")
                {
                    cart.Color = Color;
                    cart.Quantity = Quantity;
                    db.Entry(cart).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if(btn == "Delete")
                {
                    db.Carts.Remove(cart);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: Carts/Create
        [HttpPost]
        public ActionResult Create(string IdProduct, double Price, string Color, int Quantity)
        {
            Cart cart = new Cart();
            if (ModelState.IsValid)
            {
                Random r = new Random();
                long count = db.Carts.LongCount();
                string id = "CR" +r.Next(10,99)+ count.ToString("0000");
                cart.IdCart = id;
                cart.UserID = User.Identity.GetUserName();
                cart.IdProduct = IdProduct;
                cart.Price = Price;
                cart.Quantity = Quantity;
                cart.Color = Color;
                cart.Total = 4;
                db.Carts.Add(cart);
                db.SaveChanges(); 
                return RedirectToAction("../Shop/index");
            }

            ViewBag.IdProduct = new SelectList(db.Products, "IdProduct", "IdCategory", cart.IdProduct);
            return View(cart);
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
