namespace BooksStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookModel : DbContext
    {
        public BookModel()
            : base("name=BookModel")
        {
        }

        public virtual DbSet<Books> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .Property(e => e.Price)
                .HasPrecision(4, 1);
        }
    }
}
