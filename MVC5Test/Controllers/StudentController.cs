using MVC5Test.Models;
using MVC5Test.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Test.Controllers
{
    public class StudentController : Controller
    {
        StudentContext studentContext = new StudentContext();
        public StudentController( )
        {
            studentContext = new StudentContext();
        }
        // GET: Student
        public ActionResult Index()
        {
           var alist=studentContext.Students.ToList();
            var departments = studentContext.Departments.ToList();
            StudentViewModel studentViewModel = new StudentViewModel() {
                Students=alist,
                Departments=departments
            };
            
            return View(studentViewModel);
        }
    }
}