using System;
using System.Collections.Generic;
using System.Linq;

namespace MVCTaskProject.Models
{
    public class DepartmentDAL
    {
        CompanyDbContext dc = new CompanyDbContext();
        public List<Department> GetDepartments()
        {
            List<Department> Depts = new List<Department>();
            try
            {

                Depts = dc.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Depts;
        }
        public Department GetDepartment(int departmentId)
        {
            Department department;
            try
            {

                department = (from d in dc.Departments where d.DepartmentId == departmentId select d).Single();
                return department;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddDepartment(Department department)
        {
            try
            {
                dc.Departments.InsertOnSubmit(department);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateDepartment(Department newValues)
        {
            try
            {
                Department oldValues = dc.Department.Single(D => D.DepartmentId == newValues.DepartmentId);
                oldValues.DepartmentName = newValues.DepartmentName;
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteDepartment(int departmentId)
        {
            try
            {
                Department oldValues = dc.Departments.First(D => D.DepartmentId == departmentId);
                dc.Departments.DeleteOnSubmit(oldValues); //Permenant Deletion              
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


