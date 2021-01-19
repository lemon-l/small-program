using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class CartIndexVm
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}