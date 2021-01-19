using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Models;

namespace BooksStore.Controllers
{
    public class CartController : Controller
    {
        public ActionResult CartIndex(Cart cart, string returnUrl)
        {
            return View(new CartIndexVm
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        //添加到购物车
        public ActionResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Books product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
            //return View();
        }

        ////点击数量+号或点击数量-号或自己输入一个值
        //[HttpPost]
        //public ActionResult IncreaseOrDecreaseOne(Cart cart, int id, int quantity)
        //{
        //    Books product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
        //    if (product != null)
        //    {
        //        cart.IncreaseOrDecreaseOne(product, quantity);
        //    }
        //    return Json(new
        //    {
        //        msg = true
        //    });
        //    //return RedirectToAction("CartIndex");
        //}

        //从购物车移除
        public ActionResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Books product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }

        //清空购物车
        public ActionResult EmptyCart(Cart cart, string returnUrl)
        {
            cart.Clear();
            return View("Index", new ProductsListVm { Products = GetAllProducts() });
        }

        //显示购物车摘要
        public ActionResult Summary(Cart cart)
        {
            return View(cart);
        }

        private BookModel db = new BookModel();
        private List<Books> GetAllProducts()
        {
            return db.Books.ToList();
        }
    }
}