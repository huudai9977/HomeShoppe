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

namespace Home_Shoppe.Areas.Admin.Controllers
{
    public class BillsController : Controller
    {
        private HomeShopDbContext db = new HomeShopDbContext();

        [Authorize(Roles = "Admin,Maganer,Employee")]
        // GET: Admin/Bills
        public ActionResult Index()
        {
            return View(db.Bills.ToList());
        }

        // GET: Admin/Bills/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.bill = bill;
            var carts = db.Carts.SqlQuery("Select * from Carts where IdBill='" + id + "'");
            ViewBag.TotalPrice = carts.Sum(x => x.Total);
            ViewBag.TotalQuantity = carts.Sum(x => x.Quantity);
            return View(carts.ToList());
        }

        

        

        // POST: Admin/Bills/index
        
        [HttpPost,ActionName("Index")]
        public ActionResult Edit(string idbill,string Status, string btn)
        {
            if (ModelState.IsValid)
            {
                Bill bill = db.Bills.Find(idbill);
                if (btn=="Update")
                {
                    bill.Status = Status;
                    db.Entry(bill).State = EntityState.Modified;
                }
                if(btn== "Delete")
                {
                    db.Bills.Remove(bill);
                    db.SaveChanges();
                }
                db.SaveChanges();
                return RedirectToAction("Index");
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
