using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using System.Data.Entity;
using MVCTaskProject.Models;
using static MVCTaskProject.Models.Department;

namespace MVCTaskProject.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyDbContext dc = new CompanyDbContext();
        public ViewResult DisplayEmployees()
        {
            dc.Configuration.LazyLoadingEnabled = false;
            var employees = dc.Employees.Include(E => E.Department).ToList();
            return View(employees);
        }
        public ViewResult DisplayEmployee(int employeeId)
        {
            dc.Configuration.LazyLoadingEnabled = false;
            Employee employee = (dc.Employees.Include(E => E.Department).Where(E => E.EmployeeId == employeeId)).Single();
            return View(employee);
        }
        public ViewResult AddEmployee()
        {
            ViewBag.DepartmentId = new SelectList(dc.Departments, "DepartmentId", "DepartmentName");
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(Employee employee)
        {           
            dc.Employees.Add(employee);
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        public ViewResult EditEmployee(int employeeId)
        {
            Employee employee = dc.Employees.Find(employeeId);           
            ViewBag.DepartmentId = new SelectList(dc.Departments, "DepartmentId", "DepartmentName", employee.DepartmentId);
            return View(employee);
        }
        public RedirectToRouteResult UpdateEmployee(Employee employee)
        {
            dc.Entry(employee).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteProduct(int Id)
        {
            Employee employee = dc.Employees.Find(Id);          
            dc.Entry(employee).State = EntityState.Modified;
            dc.SaveChanges();
            return RedirectToAction("DisplayEmployees");
        }

    }
}