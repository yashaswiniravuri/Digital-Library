using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.Models.BookOrders;
using Microsoft.AspNet.Identity;

namespace Library.Controllers.Books
{
    
    public class BooksMenuController : Controller
    {
        // GET: BooksMenu
       BooksData Books;
        public BooksMenuController()
        {
            BooksOrder bm = new BooksOrder();
            Books = new BooksData(bm);
        }
        [HttpGet]
        [Authorize(Roles = "Member")]
        public ActionResult BooksGallery()
        {
            var model = Books.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = Books.Get(id);
            return View(model);
        }
        [Authorize(Roles="Librarian")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles ="Librarian")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LibraryBook books)
        {

            //get user id from asp.net users
            if (ModelState.IsValid)
            {
                Books.Add(books);
                return RedirectToAction("Details", new { id = books.Book_Id });
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public ActionResult Edit(int id)
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
        public ActionResult Edit(LibraryBook book)
        {
            if (ModelState.IsValid)
            {
                Books.Update(book);
                return RedirectToAction("Details", new { id = book.Book_Id });
            }
            return View(book);
        }
        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public ActionResult Delete(int id)
        {
            var model = Books.Get(id);
            if (model == null)
            {
                return View("not found");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Librarian")]
        public ActionResult Delete(int id, FormCollection form)
        {
            Books.Delete(id);
            return RedirectToAction("LibIndex");
        }
        public ActionResult LibGallery()
        {
            var model = Books.GetLib();
            return View(model.ToList());
        }
    }
}