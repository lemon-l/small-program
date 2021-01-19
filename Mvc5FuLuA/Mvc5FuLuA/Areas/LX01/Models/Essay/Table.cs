namespace Mvc5FuLuA.Areas.LX01.Models.Essay
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Table")]
    public partial class Table
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        [StringLength(20)]
        public string Author { get; set; }

        public int? Views { get; set; }
    }
}
