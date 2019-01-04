using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Employee.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext() : base("constr")
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeeLeavesModel> EmployeeLeaves { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().MapToStoredProcedures();
            modelBuilder.Entity<EmployeeLeavesModel>().MapToStoredProcedures();
        }

    }
}