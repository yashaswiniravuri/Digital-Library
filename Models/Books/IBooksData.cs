using Library.Models.Books;
using System.Collections.Generic;
namespace Library.Models.Books
{
    public interface IBooksData
    {

        IEnumerable<LibraryBook> GetAll();
        LibraryBook Get(int id);

        void Add(LibraryBook MyBooks);
        void Update(LibraryBook b);
        void Delete(int id);
    }

}
