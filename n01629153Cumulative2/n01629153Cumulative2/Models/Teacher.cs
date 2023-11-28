using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace n01629153Cumulative2.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "First Name is Required field !!")]
        public string TeacherFName { get; set; }
        [Required(ErrorMessage = "Last Name is Required field !!")]
        public string TeacherLName { get; set; }
        [Required(ErrorMessage = "Employee Number is Required field !!")]
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Hire Date is Required field !!")]
        public DateTime HireDate { get; set; }
        [RegularExpression("^ [0 - 9]")]
        [Required(ErrorMessage = "Salary is Required field !!")]
        public double Salary { get; set; }
    }
}