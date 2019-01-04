using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_EF6_Employee.Models;

namespace MVC_EF6_Employee.Controllers
{
    public class EmployeesController : Controller
    {
        MyDBContext db = new MyDBContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var count = db.Employees.Count(c => c.EmployeeID == model.LoginID && c.EmployeePassword == model.Password);
                if (count > 0)
                {
                    Session["loginid"] = model.LoginID;
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ViewBag.msg = "Invalid ID or Password";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Index()
        {
            int loginid = Convert.ToInt32(Session["loginid"]);
            ViewBag.loginid = loginid;
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(EmployeeModel model)
        {
            db.Employees.Add(model);
            db.SaveChanges();
            ViewBag.msg = "Employee Added : " + model.EmployeeID;
            return View();
        }
        public ActionResult Search()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            return View(list);
        }
        [HttpPost]
        public ActionResult Search(string key)
        {
            var data = db.Employees.Where(c => c.EmployeeID.ToString().Contains(key) || c.EmployeeName.Contains(key) || c.EmployeeCity.Contains(key) ).ToList();
            return View(data);
        }
        public ActionResult Find(int id)
        {
            var model = db.Employees.FirstOrDefault(c => c.EmployeeID == id);
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Employees.FirstOrDefault(c => c.EmployeeID == id);
            db.Employees.Remove(model);
            db.SaveChanges();
            return View("v_employeedeleted");
        }
        public ActionResult Edit(int id)
        {
            var model = db.Employees.FirstOrDefault(c => c.EmployeeID == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            var dbmodel = db.Employees.FirstOrDefault(c => c.EmployeeID == model.EmployeeID);
            dbmodel.EmployeeCity = model.EmployeeCity;
            dbmodel.EmployeeSalary = model.EmployeeSalary;
            db.SaveChanges();
            return View("v_updated");
        }
    }
}