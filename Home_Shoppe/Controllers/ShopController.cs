using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Home_Shoppe.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        // GET: Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        // GET: Shop/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shop/Edit/5
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

        // GET: Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shop/Delete/5
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
