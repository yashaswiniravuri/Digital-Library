using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Library.Models.Books
{
    public class SqlBooksData:IBooksData
    {
        private readonly BooksModel db;

        public SqlBooksData(BooksModel db)
        {
            this.db = db;
        }

        public void Add(LibraryBook MyBooks)
        {
            MyBooks.Lib_Id=System.Web.HttpContext.Current.User.Identity.GetUserId();
            db.LibraryBooks.Add(MyBooks);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = db.LibraryBooks.Find(id);
            db.LibraryBooks.Remove(b);
            db.SaveChanges();
        }

        public LibraryBook Get(int id)
        {
            return db.LibraryBooks.FirstOrDefault(r => r.Book_Id == id);
        }

        public IEnumerable<LibraryBook> GetAll()
        {
            return db.LibraryBooks;
        }

        public void Update(LibraryBook b)
        {
            b.Lib_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            var entry = db.Entry(b);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}