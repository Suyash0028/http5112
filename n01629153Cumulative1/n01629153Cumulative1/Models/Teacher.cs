﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01629153Cumulative1.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFName { get; set; }
        public string TeacherLName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public double Salary { get; set; }
    }
}