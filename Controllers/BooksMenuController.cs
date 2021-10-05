using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using Library.Models.Books;

namespace Library.Controllers.Books
{
    public class BooksMenuController : Controller
    {
        // GET: BooksMenu
        SqlBooksData sqlBooksData;
        public BooksMenuController()
        {
            BooksModel bm = new BooksModel();
            sqlBooksData = new SqlBooksData(bm);
        }

        [HttpGet]
        [Authorize(Roles = "Member")]
        public ActionResult Index()
        {
            var model = sqlBooksData.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = sqlBooksData.Get(id);
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
                sqlBooksData.Add(books);
                return RedirectToAction("Details", new { id = books.Book_Id });
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public ActionResult Edit(int id)
        {
            var model = sqlBooksData.Get(id);
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
                sqlBooksData.Update(book);
                return RedirectToAction("Details", new { id = book.Book_Id });
            }
            return View(book);
        }
        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public ActionResult Delete(int id)
        {
            var model = sqlBooksData.Get(id);
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
            sqlBooksData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}