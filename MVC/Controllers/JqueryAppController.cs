using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class JqueryAppController : Controller
    {
        // GET: JqueryApp
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllEmployee()
        {
            List<Employee> emplist;
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                emplist = context.Employees.ToList();
            }
            return Json(emplist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Employee emp = new Employee();
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                emp.DeptList = context.Departments.ToList();
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            return View();
        }

    }
}