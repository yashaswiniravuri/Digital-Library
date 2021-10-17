using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.BookOrders
{
   public interface IUserData
    {
        IEnumerable<AspNetUser> GetAll();
        AspNetUser Get(string id);

    }
    public class UserData : IUserData
    {
        private readonly BooksOrder db;
        public UserData(BooksOrder db)
        {
            this.db = db;
        }
        public AspNetUser Get(string id)
        {
            return db.AspNetUsers.FirstOrDefault(r => r.Id==id);
        }
        public IEnumerable<AspNetUser> GetAll()
        {
            return db.AspNetUsers;
        }
    }
}
