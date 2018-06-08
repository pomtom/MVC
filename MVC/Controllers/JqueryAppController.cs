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
            List<Employee> emplist = GetAllEmployees();
            return Json(emplist, JsonRequestBehavior.AllowGet);
        }

        
        public PartialViewResult _EmpList()
        {
            List<Employee> emplist = GetAllEmployees();
            return PartialView(emplist);
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
            if (emp != null)
            {
                using (EmployeeDBContext context = new EmployeeDBContext())
                {
                    context.Employees.Add(emp);
                    context.SaveChanges();
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            Employee emp;
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                emp = context.Employees.FirstOrDefault(a => a.Id == id);
                emp.DeptList = context.Departments.ToList();
            }
            return View(emp);
        }

        private static List<Employee> GetAllEmployees()
        {
            List<Employee> emplist;
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                emplist = context.Employees.ToList();
            }
            return emplist;
        }
    }
}