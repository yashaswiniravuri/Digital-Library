namespace Library.Models.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_Id { get; set; }

        public int Book_Id { get; set; }

        [StringLength(10)]
        public string Librarian_Id { get; set; }

        [StringLength(10)]
        public string Member_id { get; set; }
    }
}
