namespace Library.Models.BookOrders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LibraryBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LibraryBook()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Book_Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(128)]
        public string Lib_Id { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public int? Copies { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public string Description { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
