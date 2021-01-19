namespace Mvc5FuLuA.Areas.LX01.Models.Essay
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.Content)
                .IsFixedLength();

            modelBuilder.Entity<Table>()
                .Property(e => e.Author)
                .IsFixedLength();
        }
    }
}
