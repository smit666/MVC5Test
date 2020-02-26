using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Test.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string  MobileNo { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
    }
}