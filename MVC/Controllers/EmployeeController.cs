using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<Employee> emps;
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                emps = context.Employees.AsNoTracking().Include("Departments").ToList();
            }
            return View(emps);
        }

        public ActionResult Create()
        {
            //https://www.pluralsight.com/guides/asp-net-mvc-populating-dropdown-lists-in-razor-views-using-the-mvvm-design-pattern-entity-framework-and-ajax
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                var departments = context.Departments.ToList();
                Employee emp = new Employee();
                emp.DeptList = departments.ToList();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid)
            {
                using (EmployeeDBContext context = new EmployeeDBContext())
                {
                    var departments = context.Departments.ToList();
                    emp.DeptList = departments.ToList();
                    return View(emp);
                }
            }

            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                Employee emp = context.Employees.FirstOrDefault(a => a.Id == id);
                emp.DeptList = context.Departments.ToList();
                return View(emp);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            using (EmployeeDBContext context = new EmployeeDBContext())
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                Employee findemp = context.Employees.FirstOrDefault(a => a.Id == emp.Id);
                if (findemp != null)
                {
                    context.Entry(findemp).CurrentValues.SetValues(emp);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
        }
    }
}