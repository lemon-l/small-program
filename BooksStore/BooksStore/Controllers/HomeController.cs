using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Models;
namespace BooksStore.Controllers
{
    public class HomeController : Controller
    {
        private BookModel db = new BookModel();
        public ActionResult Index(Cart cart)
        {
            return View(cart);
        }

        public ActionResult SpecialPrice()
        {
            return View();
        }

        public ActionResult Ranklist()
        {
            var ps = from s in db.Books select s;
            ps = ps.OrderByDescending(s => s.count);          
            return View(ps.ToList());
        }

        public ActionResult NewBooks()
        {
            return View();
        }
    }
}