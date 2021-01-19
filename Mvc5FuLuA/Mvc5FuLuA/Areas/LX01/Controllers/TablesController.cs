using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc5FuLuA.Areas.LX01.Models.Essay;

namespace Mvc5FuLuA.Areas.LX01.Controllers
{
    public class TablesController : Controller
    {
        private Model1 db = new Model1();

        // GET: LX01/Tables
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView(db.Table.ToList());
            else
                return View(db.Table.ToList());
        }

        // GET: LX01/Tables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Table.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (Request.IsAjaxRequest())
                {
                    return PartialView(table);
                }                 
                else
                    return View(table);
            }
        }

        // GET: LX01/Tables/Create
        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }

        // POST: LX01/Tables/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Date,Content,Author,Views")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Table.Add(table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return PartialView(table);
                else
                    return View(table);
            }
        }

        // GET: LX01/Tables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Table.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return PartialView(table);
                else
                    return View(table);
            }
        }

        // POST: LX01/Tables/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Title,Date,Content,Author,Views")] Table table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return PartialView(table);
                else
                    return View(table);
            }
        }

        // GET: LX01/Tables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table table = db.Table.Find(id);
            if (table == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return PartialView(table);
                else
                    return View(table);
            }
        }

        // POST: LX01/Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table table = db.Table.Find(id);
            db.Table.Remove(table);
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
    }
}
