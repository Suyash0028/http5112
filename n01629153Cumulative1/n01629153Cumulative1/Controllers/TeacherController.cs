using MySql.Data.MySqlClient;
using n01629153Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace n01629153Cumulative1.Controllers
{
    public class TeacherController : Controller
    {
      
        /// <summary>
        /// This Function returns the view and the List.cshtml file gets rendered
        /// For ex: /Teacher/List
        /// Go to /Views/Teacher/List.cshtml
        /// </summary>
        /// <returns>Sends the data model to the view and then in view it gets rendered</returns>
        public ActionResult List()
        {
           
            TeacherDataController teacherDataController = new TeacherDataController();
            IEnumerable<Teacher> DataModel = teacherDataController.FetchTeachersData();

            return View(DataModel);
        }

        /// <summary>
        /// This function returns the view and the Show.cshtml files gets rendered
        /// For ex: /Teacher/Show
        // GET : /Teacher/Show/{Id}
        ///Route to /Views/Teacher/Show.cshtml
        /// </summary>
        /// <returns>Sends the data model to the view and then in view it gets rendered</returns>
        public ActionResult Show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher SelectedTeacher = teacherDataController.FindTeacher(id);
            // we want to show a particular teacher given the id
            return View(SelectedTeacher);
        }
    }
}
