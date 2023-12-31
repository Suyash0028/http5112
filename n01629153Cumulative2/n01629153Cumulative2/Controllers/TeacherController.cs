﻿using n01629153Cumulative2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01629153Cumulative2.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This Function returns the view and the List.cshtml file gets rendered
        /// For ex: /Teacher/List
        /// Go to /Views/Teacher/List.cshtml
        /// </summary>
        /// <returns>Sends the data model to the view and then in view it gets rendered</returns>
        public ActionResult List(string SearchKey = null)
        {

            TeacherDataController teacherDataController = new TeacherDataController();
            IEnumerable<Teacher> DataModel = teacherDataController.ListTeachers(SearchKey);

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

        //GET : /Teacher/DeleteConfirm/{id}
        /// <summary>
        /// This view is just to take confirmation about the delete action which they have requested for
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }


        //POST : /Teacher/Delete/{id}
        /// <summary>
        /// This function is use to delete the teacher from the database and redirect to the list view
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List view</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //GET : /Teacher/New_JSValidation
        public ActionResult New_JSValidation()
        {
            return View();
        }

        //POST : /Teacher/New
        [HttpPost]
        public ActionResult New(Teacher NewTeacher)
        {
            //This Modelstate is used to validate that the mentioned required fields in the model has value in those fields then it returns true otherwise false
            if (ModelState.IsValid)
            {
                Teacher TeacherData = new Teacher();
                TeacherData.TeacherFName = NewTeacher.TeacherFName;
                TeacherData.TeacherLName = NewTeacher.TeacherLName;
                TeacherData.EmployeeNumber = NewTeacher.EmployeeNumber;
                TeacherData.HireDate = Convert.ToDateTime(NewTeacher.HireDate);
                TeacherData.Salary = Convert.ToDouble(NewTeacher.Salary);

                TeacherDataController controller = new TeacherDataController();
                controller.AddTeacher(TeacherData);

                return RedirectToAction("List");
            }
            return View(NewTeacher);
        }
    }
}