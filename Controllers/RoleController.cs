using Library.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
       
        // GET all Roles
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        //create a new role
        //Role creation is done using IdentityRole class.
        //This class provides properties e.g.Id, Name, etc for creating roles for the applications.
        //Scaffold the Index and Create view, using Index and Create Action method from the RoleController class.


        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        //http post
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            context.Roles.Add(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}