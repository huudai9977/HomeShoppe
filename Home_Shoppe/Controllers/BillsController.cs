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

namespace Home_Shoppe.Controllers
{
    public class BillsController : Controller
    {
        private HomeShopDbContext db = new HomeShopDbContext();

        

        

        // GET: Bills/Create
        public ActionResult Pay()
        {
            var carts = db.Carts.SqlQuery("Select * from Carts where UserID='" + User.Identity.GetUserName() + "' and IdBill IS NULL");
            ViewBag.TotalPrice = carts.Sum(x => x.Total);
            ViewBag.TotalQuantity = carts.Sum(x => x.Quantity);
            
            return View(carts.ToList());
        }

        // POST: Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Pay(string ReceiverName,string Phone,string DiliveryAddress,string Note,double TotalPayment,int TotalQuantity)
        {
            Bill bill = new Bill();
            if (ModelState.IsValid)
            {
                Random r = new Random();
                long count = db.Bills.LongCount();
                string id = "CR" + r.Next(10, 99) + count.ToString("0000");
                bill.IdBill = id;
                bill.UserID = User.Identity.GetUserName();
                bill.ReceiverName = ReceiverName;
                bill.Phone = Phone;
                bill.DiliveryAddress = DiliveryAddress;
                bill.Time = DateTime.Now;
                bill.Status = "Wait for confirmtion";
                bill.TotalPayment = TotalPayment;
                bill.TotalQuantity = TotalQuantity;
                bill.Note = Note;
                db.Bills.Add(bill);
                //var update =db.Database.ExecuteSqlCommand("UPDATE Carts SET IdBill = '" + id + "' WHERE UserID = '" + User.Identity.GetUserName() + "' and IdBill IS NULL");
                var carts = db.Carts.SqlQuery("Select * from Carts where UserID='" + User.Identity.GetUserName() + "' and IdBill IS NULL");
                foreach(var cart in carts)
                {
                    cart.IdBill = id;
                    db.Entry(cart).State = EntityState.Modified;
                }
                
                db.SaveChanges();
                return RedirectToAction("../Shop/index");
            }

            return View();
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
