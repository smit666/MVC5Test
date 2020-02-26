using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Test.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}