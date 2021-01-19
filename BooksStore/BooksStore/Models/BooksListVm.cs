using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class ProductsListVm
    {
        public ProductsListVm()
        {
            this.Products = new List<Books>();
        }
        public IEnumerable<Books> Products { get; set; }
    }
}