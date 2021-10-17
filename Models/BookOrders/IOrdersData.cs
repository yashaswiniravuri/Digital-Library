using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BookOrders
{
    public interface IOrdersData
    {
        IEnumerable<Order> GetAllMemOrders(string memid);
        IEnumerable<Order> GetAllLibOrders(string libid);
        Order Get(int id);
        void Add(string lib,int bid, Order MyOrder);
        void Borrow(Order o);
        void Return(Order o);
        void Delete(int id);
    }
    public class OrdersData : IOrdersData
    {
        private readonly BooksOrder db;
        public OrdersData(BooksOrder db)
        {
            this.db = db;
        }
        public void Add(string lib,int bid, Order MyOrder)
        {
            MyOrder.Member_id = System.Web.HttpContext.Current.User.Identity.GetUserId();
            MyOrder.Book_Id = bid;
            MyOrder.Librarian_Id=lib;
            MyOrder.Borrow_Date = DateTime.Today;
            MyOrder.Due_Date = DateTime.Today.AddDays(15);
            MyOrder.Status=StatusType.To_be_borrowed;
            db.Orders.Add(MyOrder);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var b = db.Orders.Find(id);
            db.Orders.Remove(b);
            db.SaveChanges();
        }

        public Order Get(int id)
        {
            return db.Orders.FirstOrDefault(r => r.Order_Id == id);
        }

        public IEnumerable<Order> GetAllLibOrders(string libid)
        {
            return db.Orders.Where(r=>r.Librarian_Id==libid);
        }

        public IEnumerable<Order> GetAllMemOrders(string memid)
        {
            return db.Orders.Where(r => r.Member_id == memid);
        }

        public void Borrow(Order o)
        {
            
            o.Status=StatusType.Borrowed;
            var entry = db.Entry(o);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Return(Order o)
        {

            o.Status = StatusType.Returned;
            var entry = db.Entry(o);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

    }
}
