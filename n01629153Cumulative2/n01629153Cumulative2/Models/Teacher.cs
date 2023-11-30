using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace n01629153Cumulative2.Models
{
    public class Teacher
    {
        //Model created according to the fields available in the database
        public int TeacherId { get; set; }
        //This is used to make the field required with error message attached to it
        [Required(ErrorMessage = "First Name is Required field !!")]
        public string TeacherFName { get; set; }
        [Required(ErrorMessage = "Last Name is Required field !!")]
        public string TeacherLName { get; set; }
        [Required(ErrorMessage = "Employee Number is Required field !!")]
        public string EmployeeNumber { get; set; }
        [Required(ErrorMessage = "Hire Date is Required field !!")]
        [DataType(DataType.DateTime)]
        public DateTime HireDate { get; set; }
        //This is regex to validate the user has added 0-9 numbers only no strings used
        [RegularExpression("^[0-9]*$")]
        [Required(ErrorMessage = "Salary is Required field !!")]
        public double Salary { get; set; }
    }
}