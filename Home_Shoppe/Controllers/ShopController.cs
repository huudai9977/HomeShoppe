using Home_Shoppe.Models;
using Microsoft.AspNet.Identity;
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
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product Where QuantityInStock>0 ORDER BY IdProduct DESC");
            return c;
        }

        public static IEnumerable<Product> RelatedProduct(string id)
        {
            var dba = new HomeShopDbContext();
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product where QuantityInStock>0 and IdCategory='" + id + "'"+" ORDER BY Views DESC");
            return c;
        }

        public static IEnumerable<Product> FeatureProduct()
        {
            var dba = new HomeShopDbContext();
            var c = dba.Products.SqlQuery("Select TOP(4) * from Product Where QuantityInStock>0 ORDER BY Views DESC");
            return c;
        }
        // GET:  all Product
        public ActionResult AllProduct(int page=1,int pagesize=12 )
        {
            var p = db.Products.SqlQuery("Select * from Product Where QuantityInStock>0 ").ToPagedList(page,pagesize);
            return View(p);
        }
        //GET: Data
        public ActionResult Category(string id,int page = 1, int pagesize = 12)
        {
            var p = db.Products.SqlQuery("Select * from Product where QuantityInStock>0 and IdCategory='" + id+"'").ToPagedList(page, pagesize);
            ViewBag.NameCategory = db.Categories.SingleOrDefault(a => a.IdCategory == id).NameCategory;
            return View(p);
        }

        // GET: Shop/Details/5
        public ActionResult Details(string id)
        {
            
            var view = db.Products.SingleOrDefault(a => a.IdProduct == id );
            
            return View(view);
        }
        
        [HttpPost]
       
        public ActionResult CreateCart(string IdProduct, double Price, string Color, int Quantity)
        {
            Cart cart = new Cart();
            if (ModelState.IsValid)
            {
                long count = db.Carts.LongCount();
                string id = "CART" + count.ToString("00000");
                cart.IdCart = "test123";
                cart.UserID = User.Identity.GetUserId();
                cart.IdProduct = "P00008";
                cart.Price = Price;
                cart.Quantity = 1;
                cart.Color = "blue";
                cart.Total = 4;
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        //GET: shop/search

        [HttpPost]
        public ActionResult Search(string Search, int page = 1, int pagesize = 8)
        {
            var products = db.Products.SqlQuery("Select * from Product Where QuantityInStock>0 ").ToPagedList(page, pagesize);
            //var resultList = products;
            //if (!String.IsNullOrEmpty(Search))
            // resultList = products.Where(t => t.NameProduct.Contains(Search)).ToPagedList(page, pagesize);
            ViewBag.keyword = Search;
            return View(products);

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
