using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BookOrders
{
    public interface IBooksData
    {
        IEnumerable<LibraryBook> GetAll();
        LibraryBook Get(int id);
        IEnumerable<LibraryBook> GetLib();
        void Add(LibraryBook MyBooks);
        void Update(LibraryBook b);
        void Delete(int id);
    }
    public class BooksData : IBooksData
    {
        private readonly BooksOrder db;
        public BooksData(BooksOrder db)
        {
            this.db = db;
        }
        public IEnumerable<LibraryBook> GetLib()
        {
            var Lib_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return db.LibraryBooks.Where(r => r.AspNetUser.Id == Lib_Id);
        }
        public void Add(LibraryBook MyBooks)
        {
            MyBooks.Lib_Id = System.Web.HttpContext.Current.User.Identity.GetUserId();
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
