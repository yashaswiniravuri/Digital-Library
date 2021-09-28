using Library.Data.Models;
using Library.Data.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CartController : Controller
    {
        
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Borrow(string id)
        {
            InMemoryBookData book = new InMemoryBookData();
            if(Session["Cart"]==null)
            {
                List<Item> Cart = new List<Item>();
                Cart.Add(new Item { Books = book.find(id),Quantity =1});
                Session["Cart"] = Cart;
            }
            else
            {
                List<Item> Cart = (List<Item>)Session["Cart"];
                int index = isExist(id);
                if(index != -1)
                {
                    Cart[index].Quantity++;

                    
                }
                else
                {
                    Cart.Add(new Item { Books = book.find(id), Quantity = 1 });
                }
                Session["Cart"] = Cart;

            }
            return RedirectToAction("Index");
            //return View();
        }

        private int isExist(string id)
        {
            List<Item> Cart = (List<Item>)Session["Cart"];
            for(int i=0;i<Cart.Count;i++)
            {
                if (Cart[i].Books.Book_id.Equals(id))
                {
                    return i;
                }

            }
            return -1;
            //throw new NotImplementedException();
        }
    }
}