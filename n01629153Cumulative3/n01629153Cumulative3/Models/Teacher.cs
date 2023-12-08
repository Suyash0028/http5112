using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace n01629153Cumulative3.Models
{
    public class Teacher
    {
        //Model created according to the fields available in the database
        /// <summary>
        /// Database Field name - Model Field name
        /// teacherid - TeacherId
        /// teacherfname - TeacherFName
        /// teacherlname - TeacherLName
        /// hiredate - HireDate
        /// employeenumber - EmployeeNumber
        /// salary - Salary
        /// </summary>
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
        [RegularExpression("^[1-9]\\d*(\\.\\d+)?$")]
        [Required(ErrorMessage = "Salary is Required field !!")]
        public double Salary { get; set; }



        // Validation for the model
        public bool IsValid()
        {
            bool valid = true;

            if (TeacherFName == null || TeacherLName == null || EmployeeNumber == null || HireDate == null)
            {
                //Base validation to check if the fields are entered.
                valid = false;
            }
            else
            {
                //Validation for fields to make sure they meet server constraints
                if (TeacherFName.Length < 2 || TeacherFName.Length > 255) valid = false;
                if (TeacherLName.Length < 2 || TeacherLName.Length > 255) valid = false;
                //C# email regex 
                //https://stackoverflow.com/questions/5342375/regex-email-validation

                Regex SalaryRegex = new Regex(@"^[1-9]\d*(\.\d+)?$");
                if (!SalaryRegex.IsMatch(Convert.ToString(Salary))) valid = false;
            }
            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }
    }
}