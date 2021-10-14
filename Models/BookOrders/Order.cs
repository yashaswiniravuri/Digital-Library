namespace Library.Models.BookOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        public int Order_Id { get; set; }

        public int? Book_Id { get; set; }

        [StringLength(128)]
        public string Librarian_Id { get; set; }

        [StringLength(128)]
        public string Member_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Borrow_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Due_Date { get; set; }

        public bool? Status { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }//librarian user

        public virtual AspNetUser AspNetUser1 { get; set; }//member user

        public virtual LibraryBook LibraryBook { get; set; }
    }
}
