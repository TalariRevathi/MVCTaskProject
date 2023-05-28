using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCTaskProject.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("ConStr")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CompanyDbContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<CompanyDbContext>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().MapToStoredProcedures(S => S.Insert(X => X.HasName("Employee_Insert")));
            modelBuilder.Entity<Employee>().MapToStoredProcedures(S => S.Update(X => X.HasName("Employee_Update_Student")));
            modelBuilder.Entity<Employee>().MapToStoredProcedures(S => S.Delete(X => X.HasName("Employee_Delete")));
        }


    



}
}