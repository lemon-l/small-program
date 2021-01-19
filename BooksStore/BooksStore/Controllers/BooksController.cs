using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BooksStore.Models;

namespace BooksStore.Controllers
{
    public class BooksController : Controller
    {
        private BookModel db = new BookModel();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Test()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Search(string search)
        {
            ViewBag.search = search;
            var t = db.Books.ToList();
            if (string.IsNullOrEmpty(search) == false)
                t = t.Where(item => item.Name.Contains(search)).ToList();
            return View(t);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,Category")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Price,Category")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        string Cate;
        public ActionResult Computer()
        {
            Cate = "Computer";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }

        public ActionResult Digital()
        {
            string Cate = "Digital";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }

        public ActionResult Industry()
        {
            string Cate = "Industry";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }

        public ActionResult Manage()
        {
            string Cate = "Manage";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }

        public ActionResult Psychology()
        {
            string Cate = "Psychology";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }

        public ActionResult Textbook()
        {
            string Cate = "Textbook";
            var list = from c in db.Books where c.Category == Cate select c;
            return View(list);
        }
    }
}
