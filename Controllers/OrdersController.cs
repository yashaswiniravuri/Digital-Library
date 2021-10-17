using Library.Models;
using Library.Models.BookOrders;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class OrdersController : Controller
    {
        BooksData Books;
        OrdersData Orders;
        UserData Users;
        public OrdersController()
        {
            BooksOrder bo = new BooksOrder();
            Orders = new OrdersData(bo);
            Books = new BooksData(bo);
            Users = new UserData(bo);
        }


        [Authorize(Roles = "Librarian")]
        public ActionResult LibIndex()
        {
            var libid = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var model = Orders.GetAllLibOrders(libid);
            return View(model);
        }


        [Authorize(Roles = "Member")]
        public ActionResult MemIndex()
        {
            var Member_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var model = Orders.GetAllMemOrders(Member_id);
            return View(model);
        }


        [Authorize(Roles = "Member")]
        public ActionResult Create(int id,Order order)
        {
            var book = Books.Get(id);
            Orders.Add(book.Lib_Id, book.Book_Id, order);
            return RedirectToAction("MemIndex");
        }
     

        [Authorize(Roles = "Member")]
        public ActionResult Delete(int id)
        {
            Orders.Delete(id);
            return RedirectToAction("MemIndex");
        }


        public ActionResult Borrow(int id)
        {
            Orders.Borrow(Orders.Get(id));
            return RedirectToAction("MemIndex");
        }


        public ActionResult Return(int id)
        {
            Orders.Return(Orders.Get(id));
            return RedirectToAction("MemIndex");
        }


        public ActionResult Details(int id){
            var model = Books.Get(id);
            return View(model);
        }


        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public ActionResult Update(int id)
        {
            var model = Books.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Librarian")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(LibraryBook book)
        {
            if (ModelState.IsValid)
            {
                Books.Update(book);
                return RedirectToAction("LibIndex");
            }
            return View(book);
        }
    }
}