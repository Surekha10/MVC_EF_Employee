using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF6_Employee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.msg = "Employee Details";
            return View();
        }
    }
}