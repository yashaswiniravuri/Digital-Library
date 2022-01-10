using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Library.Models.BookOrders
{
    public partial class BooksOrder : DbContext
    {
        public BooksOrder()
            : base("name=BooksOrder")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<LibraryBook> LibraryBooks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.LibraryBooks)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Lib_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Librarian_Id);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.AspNetUser1)
                .HasForeignKey(e => e.Member_id);

            modelBuilder.Entity<LibraryBook>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
