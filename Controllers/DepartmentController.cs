using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVCTaskProject.Models;
using static MVCTaskProject.Models.Employee;

namespace MVCTaskProject.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       

        CompanyDbContext dc = new CompanyDbContext();

        // GET: Departments
        public ViewResult DisplayDepartments()
        {
            var departments = dc.Departments.ToList();
            return View(departments);
        }
        // GET: Add Department
        public ViewResult AddDepartment()
        {
            Department department = new Department();
            return View(department);
        }
        [HttpPost]
        public RedirectToRouteResult AddDepartment(Department department)
        {
            dc.Departments.Add(department);
            dc.SaveChanges();
            return RedirectToAction("DisplayDepartments");
        }
        public ViewResult EditDepartment(int departmentId)
        {
            Department department = dc.Departments.Find(departmentId);
            return View(department);
        }
        public RedirectToRouteResult UpdateDepartment(Department department)
        {
            dc.Entry(department).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayDepartments");
        }
        public RedirectToRouteResult DeleteDepartment(int departmentId)
        {
            Department department = dc.Departments.Find(departmentId);
            dc.Departments.Remove(department);
            dc.SaveChanges();
            return RedirectToAction("DisplayDepartments");
        }

    }
}