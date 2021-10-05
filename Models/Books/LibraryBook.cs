namespace Library.Models.Books
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LibraryBook
    {
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
    }
}
