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
                StudentsList=alist,
                Departments=departments
            };
            
            return View(studentViewModel);
        }
        public ActionResult Add()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Add(StudentViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                viewModel.Student.IsActive = true;

                studentContext.Students.Add(viewModel.Student);
                studentContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          
        }

        public Student GetStudentById(int id)
        {
            var result = studentContext.Students.Where(m => m.StudentId == id).SingleOrDefault();

            return result;
        }

        public ActionResult Edit(int id)
        {
            var resultJoin = studentContext.Students.Join(studentContext.Departments, m => m.DepartmentId, d => d.DepartmentId, (m, d) => new
            {
                Name = m.Name,
                DepartmenName = d.Name

            }).Take(5);
            StudentViewModel studentView = new StudentViewModel
            {
                Student = GetStudentById(id)
               
            };
            return View(studentView);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            var result = studentContext.Students.Where(m => m.StudentId == studentViewModel.Student.StudentId).FirstOrDefault();
     
            if (ModelState.IsValid)
            {
                studentViewModel.Student.IsActive = true;
                studentContext.Entry(result).CurrentValues.SetValues(studentViewModel.Student);
                studentContext.SaveChanges();
          
                return RedirectToAction("Index");
            }
            else
            {
                StudentViewModel studentView = new StudentViewModel
                {
                    Student = GetStudentById(studentViewModel.Student.StudentId)
                };
                return View(studentView);
            }
           
        }
    }
}