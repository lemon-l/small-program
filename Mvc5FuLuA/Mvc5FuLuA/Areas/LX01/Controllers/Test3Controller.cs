using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5FuLuA.Areas.LX01.Models;

namespace Mvc5FuLuA.Areas.LX01.Controllers
{
    public class Test3Controller : Controller
    {
        // GET: LX01/Test3
        UserInfo user = new UserInfo()
        {
            UserName = "hr",
            UserPwd = "12345",
        };

        public ActionResult Index()
        {
            return PartialView(user);
        }

        // 服务端验证
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string userName)
        {
            ViewBag.Result = "验证失败。";
            if (this.ModelState.IsValid)
            {
                ViewBag.Result = "验证成功。";
            }
            return PartialView(user);
        }

        // 客户端验证
        public ActionResult Validation1(Staff student)
        {
            if (Request.HttpMethod == "GET")
            {
                student = new Staff
                {
                    UserName = "李",
                    UserPwd = "01"
                };
                return PartialView(student);
            }
            else
            {
                return JavaScript("alert('数据已提交！')");
            }
        }
    }
}