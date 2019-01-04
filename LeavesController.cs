using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF6_Employee.Models;

namespace MVC_EF6_Employee.Controllers
{
    public class LeavesController : Controller
    {
        MyDBContext db = new MyDBContext();
        public ActionResult AddLeaves()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(EmployeeLeavesModel model)
        {
            db.EmployeeLeaves.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Leaves Added : " + model.LeavesID;
            return View();
        }
        public ActionResult ShowLeaves()
        {
            List<EmployeeLeavesModel> list = new List<EmployeeLeavesModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult ShowLeaves(string key)
        {
            var data = db.EmployeeLeaves.Where(c => c.LeavesID.ToString().Contains(key) || c.LeaveType.Contains(key)).ToList();
            return View(data);
        }
    }
}