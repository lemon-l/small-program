namespace BooksStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public decimal? Price { get; set; }

        [StringLength(20)]
        public string Category { get; set; }

        public int? count { get; set; }
    }
}
