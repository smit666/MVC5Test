using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Test.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
    }
}