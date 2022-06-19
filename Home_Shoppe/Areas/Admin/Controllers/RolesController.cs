using Home_Shoppe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Home_Shoppe.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private HomeShopDbContext db = new HomeShopDbContext();

        [Authorize(Roles = "Admin,Maganer")]

        // GET: Admin/Decentralization
        public ActionResult SetRole(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
            var s = UserManager.GetRoles(IdUser);
            if(s.Count()==0)
            {
                ViewBag.role = "no role";
            }
            else
            {
                ViewBag.role = s[0].ToString();
            }
            
            return View(userInformation);
        }

        [HttpPost, ActionName("SetRole")]
        [ValidateAntiForgeryToken]
        public ActionResult SetRole(string id, string submitButton)
        {
            UserInformation userInformation = db.UserInformations.Find(id);
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
                if (submitButton == "Admin")
                {
                    
                    if (!UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.AddToRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }
                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }
                }
                if (submitButton == "Manager")
                {


                    if (!UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.AddToRole(IdUser, "Manager");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }

                }
                if (submitButton == "Employee")
                {


                    if (!UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.AddToRole(IdUser, "Employee");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }

                }
                if (submitButton == "Delete")
                {


                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }
                }
                return RedirectToAction("SetRole");
            }
            return View();
        }
        /*
        [HttpPost, ActionName("SetRoleAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult SetRoleAdmin(string id)
        {
            UserInformation userInformation = db.UserInformations.Find(id);
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //if (Role == "Admin")
            {
                    var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
                    if (!UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.AddToRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }
                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }

                
            }
            /*
            if (Role == "Manager")
            {
                
                    var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
                    if (!UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.AddToRole(IdUser, "Manager");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }

            }
            if (Role == "Manager")
            {
                
                    var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
                    if (!UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.AddToRole(IdUser, "Employee");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }

            }
            if (Role == "Delete")
            {
               
                    var IdUser = UserManager.FindByEmail(userInformation.Email).Id;
                    if (UserManager.IsInRole(IdUser, "Employee"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Employee");
                    }
                    if (UserManager.IsInRole(IdUser, "Admin"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Admin");
                    }
                    if (UserManager.IsInRole(IdUser, "Manager"))
                    {
                        UserManager.RemoveFromRole(IdUser, "Manager");
                    }

                    
               
            }
            */
            //return RedirectToAction("Index");
            //return View();

        //}
      
    }
}
        