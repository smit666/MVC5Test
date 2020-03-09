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

            TempData["title"] = "Student";

         // IEnumerable<Student> alist = null;
           var  alist = studentContext.Students.Join(studentContext.Departments, a => a.DepartmentId, b => b.DepartmentId, (a, b) =>  new  
            {
                Name = a.Name,
                Age = a.Age,
                Email = a.Email,
                MobileNo = a.MobileNo,
                DepartmentName=b.Name,
                StudentId=a.StudentId,
                IsActive=a.IsActive
            }).ToList().Select(m=>new Student {
                Name=m.Name,
                Age=m.Age,
                Email=m.Email,
                DepartmentName=m.DepartmentName,
                MobileNo=m.MobileNo,
                StudentId=m.StudentId,
                IsActive=m.IsActive
            }).Where(m => m.IsActive == true);
            var departments = studentContext.Departments.ToList();
            StudentViewModel studentViewModel = new StudentViewModel() {
                StudentsList=alist,
                Departments=departments
            };
            
            return View(studentViewModel);
        }
        public ActionResult Add()
        {
            
            StudentViewModel studentViewModel = new StudentViewModel
            {
                Departments = studentContext.Departments.ToList()
            };
            return View(studentViewModel);
        }
        
        [HttpPost]
        public ActionResult Add(StudentViewModel viewModel)
        {

            StudentViewModel studentViewModel = new StudentViewModel
            {
                Departments = studentContext.Departments.ToList()
            };
            if (ModelState.IsValid)
            {
                viewModel.Student.IsActive = true;

                studentContext.Students.Add(viewModel.Student);
                studentContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(studentViewModel);
            }
          
        }

        public Student GetStudentById(int id)
        {
            var result = studentContext.Students.Where(m => m.StudentId == id).SingleOrDefault();

            return result;
        }

        public ActionResult Edit(int id)
        {
            var departments = studentContext.Departments.ToList();
            //var resultJoin = studentContext.Students.Join(studentContext.Departments, m => m.DepartmentId, d => d.DepartmentId, (m, d) => new
            //{
            //    Name = m.Name,
            //    DepartmenName = d.Name
            //}).Take(5);
            StudentViewModel studentView = new StudentViewModel
            {
                Student = GetStudentById(id),
                Departments=departments
               
            };
            return View(studentView);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            var result = studentContext.Students.Where(m => m.StudentId == studentViewModel.Student.StudentId).FirstOrDefault();
            var departments = studentContext.Departments.ToList();

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
                    Student = GetStudentById(studentViewModel.Student.StudentId),
                    Departments=departments
                };
                return View(studentView);
            }
           
        }

        public ActionResult Delete(int id)
        {
           var record= studentContext.Students.Where(m => m.StudentId == id);
            studentContext.Entry(record).CurrentValues.SetValues(new { IsActive = false });
            studentContext.SaveChanges();
           return RedirectToAction("Index");
        }
        }
}