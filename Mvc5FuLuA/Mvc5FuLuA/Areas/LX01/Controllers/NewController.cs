using Mvc5FuLuA.Areas.LX01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5FuLuA.Areas.LX01.Controllers
{
    public class NewController : Controller
    {
        // GET: LX01/New
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }

        public ActionResult PartialFor(string id)
        {
            ViewBag.M = id;
            return PartialView();
        }

        public ActionResult FormControlDemo2(string id)
        {
            MyClass3Model c3 = new MyClass3Model();
            return PartialView(id, c3);
        }
    }
}