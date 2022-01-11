using Library.Models;
using Library.Models.BookOrders;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var model = Orders.Get(id);
            Orders.Borrow(model);
            var lib = Users.Get(model.Librarian_Id);
            var book = Books.Get((int)model.Book_Id);
            var mem = Users.Get(model.Member_id);

            //email to member
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("yashaswiniravuri@gmail.com");
            mail.To.Add(mem.Email);
            mail.Subject = "Books At Your Door Step - Book Issue";
            mail.Body = "<html>" +
                "<head>" +
                "<title>" +
                "Successfully borrowed the book!" +
                "</title>" +
                "</head>" +
                "<body>" +
                "<p>Hey " +
                mem.UserName +
                "!</p>" +
                "<p>Thank you for borrowing the book <q>" + book.Name + "</q> from our website.</p>" +
                "<P>What do you think about the experience? Ready for another go of it?</P>" +
                "<p>Our librarian " + lib.Email +" will contact you shortly about the book delivery, for any urgent queries about the book contact our librarian through "+lib.Email+"."+
                "<p>For any queries about the website, mail us :<a href = 'mailto: yashaswiniravuri@example.com'>@Mail</a></p>" +
                "<p>Thanks,</p>" +
                "<p>The BAYDS Team</p>" +
                "</ body >" +
                "</ html > ";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new
            System.Net.NetworkCredential("yashaswiniravuri@gmail.com", "pnvnuyjpmwbwqphj");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            

            //email to librarian
            MailMessage m = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            m.From = new MailAddress("yashaswiniravuri@gmail.com");
            m.To.Add(lib.Email);
            m.Subject = "Books At Your Door Step - Book Order";
            m.Body = "<html>" +
                "<head>" +
                "<title>" +
                "Book order" +
                "</title>" +
                "</head>" +
                "<body>" +
                "<p>Dear " +
                lib.UserName +
                ",</p>" +
                "<p>Our member <q>" + mem.UserName + "</q> has ordered a book of yours called <q>" + book.Name + "</q>. Hope you deliver the book safely." +
                "<p>Please contact our member regarding the book delivery.</p>" +
                "<p>For any urgent queries about the book return, contact our library member through " + mem.Email + ".</p>"+
                "<p>Please tell us about your experience.</p>" +
                "<p>For any queries about the website, contact us through mail: <a href = 'mailto: yashaswiniravuri@example.com'>@Mail</a></p>" +
                "<p>Thanks,</p>" +
                "<p>The BAYDS Team</p>" +
                "</ body >" +
                "</ html > ";
            m.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Credentials = new
            System.Net.NetworkCredential("yashaswiniravuri@gmail.com", "pnvnuyjpmwbwqphj");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return RedirectToAction("MemIndex");
        }


        public ActionResult Return(int id)
        {
            
            var model = Orders.Get(id);
            Orders.Return(model);
            var lib = Users.Get(model.Librarian_Id);
            var book = Books.Get((int)model.Book_Id);
            var mem = Users.Get(model.Member_id);

            //email to member
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("yashaswiniravuri@gmail.com");
            mail.To.Add(mem.Email);
            mail.Subject = "Books At Your Door Step - Book Return";
            mail.Body = "<html>" +
                "<head>" +
                "<title>" +
                "Successfully placed the return!" +
                "</title>" +
                "</head>" +
                "<body>" +
                "<p>Hey " +
                mem.UserName+
                "<!</p>" +
                "<p>Thank you for returning the book, your return for the book <q>"+book.Name+"</q> is successfully placed.</p>" +
                "<P>What do you think about the experience? Ready for another go of it?</P>" +
                "<p>For further details about the book, please contact our librarian through " +lib.Email+".</p>"+
                "<p>For any queries about the website, contact us through mail: <a href = 'mailto: yashaswiniravuri@example.com'>@Mail</a></p>" +
                "<p>Thanks,</p>" +
                "<p>The BAYDS Team</p>"+
                "</ body >" +
                "</ html > ";
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new
            System.Net.NetworkCredential("yashaswiniravuri@gmail.com", "pnvnuyjpmwbwqphj");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            
            //email to librarian
            MailMessage m = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            m.From = new MailAddress("yashaswiniravuri@gmail.com");
            m.To.Add(lib.Email);
            m.Subject = "Books At Your Door Step - Book Return";
            m.Body = "<html>" +
                "<head>" +
                "<title>" +
                "Successfully placed the return!" +
                "</title>" +
                "</head>" +
                "<body>" +
                "<p>Dear " +
                lib.UserName +
                "</q>,</p>" +
                "<p>Our member <q>"+mem.UserName+"</q> has placed a return for the book. <q>" +book.Name+"</q> Hope you get the book safely."+
                "<P>Please tell us about your experience.</P>" +
                "<p>For further details about the book delivery, please contact our library member through <q>" + mem.Email +"</q></p>"+
                "<p>For any queries about the website, contact us through mail: <a href = 'mailto: yashaswiniravuri@example.com'>@Mail</a></p>" +
                "<p>Thanks,</p>" +
                "<p>The BAYDS Team</p>" +
                "</ body >" +
                "</ html > ";
            m.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Credentials = new
            System.Net.NetworkCredential("yashaswiniravuri@gmail.com", "pnvnuyjpmwbwqphj");
            smtp.EnableSsl = true;
            smtp.Send(m);
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