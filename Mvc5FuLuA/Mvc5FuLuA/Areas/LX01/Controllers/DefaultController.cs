using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5FuLuA.Areas.LX01.Controllers
{
    public class DefaultController : Controller
    {
        // GET: LX01/Default
        public ActionResult Index()
        {
            String name = Request["UserName"];
            String pwd = Request["pwd"];
            ViewBag.Test = name + "  " + pwd;

            if (Request.IsAjaxRequest())
            {

                return PartialView();
            }
            else
                return View();
        }
    }
}