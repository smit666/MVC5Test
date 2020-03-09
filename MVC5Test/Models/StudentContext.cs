using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5Test.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext():base("StudentDb")
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}