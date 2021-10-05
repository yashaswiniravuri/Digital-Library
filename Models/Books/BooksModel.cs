using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Library.Models.Books
{
    public partial class BooksModel : DbContext
    {
        public BooksModel()
            : base("name=BooksModel1")
        {
        }

        public virtual DbSet<LibraryBook> LibraryBooks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryBook>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
