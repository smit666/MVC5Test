using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5Test.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string  MobileNo { get; set; }
        [Display(Name ="Department Name")]
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }
    }
}