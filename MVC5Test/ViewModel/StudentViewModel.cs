using MVC5Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Test.ViewModel
{
    public class StudentViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public  IEnumerable<Department> Departments { get; set; }
    }
}