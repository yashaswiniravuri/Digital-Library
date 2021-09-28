using Library.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class MenuController : Controller
    {
        BookData db;
        // GET: Menu
        public MenuController()
        {
            db = new InMemoryBookData();
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
    }
}