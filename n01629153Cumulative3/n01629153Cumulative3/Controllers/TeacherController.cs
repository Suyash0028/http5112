using n01629153Cumulative3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace n01629153Cumulative3.Controllers
{
    public class TeacherController : Controller
    {
        private TeacherDataController teacherDataController = new TeacherDataController();
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
            Teacher NewTeacher = teacherDataController.FindTeacher(id);


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
            teacherDataController.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult Add()
        {
            return View();
        }

        //GET : /Teacher/New_JSValidation
        public ActionResult New_JSValidation()
        {
            return View();
        }

        //POST : /Teacher/Add
        [HttpPost]
        public ActionResult Add(Teacher NewTeacher)
        {
            //This Modelstate is used to validate that the mentioned required fields in the model has value in those fields then it returns true otherwise false
            if (ModelState.IsValid)
            {
                Teacher TeacherData = new Teacher();
                TeacherData.TeacherFName = NewTeacher.TeacherFName;
                TeacherData.TeacherFName = NewTeacher.TeacherFName;
                TeacherData.TeacherLName = NewTeacher.TeacherLName;
                TeacherData.EmployeeNumber = NewTeacher.EmployeeNumber;
                TeacherData.HireDate = Convert.ToDateTime(NewTeacher.HireDate);
                TeacherData.Salary = Convert.ToDouble(NewTeacher.Salary);

                teacherDataController.AddTeacher(TeacherData);

                return RedirectToAction("List");
            }
            return View(NewTeacher);
        }

        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" Page. 
        /// </summary>
        /// <param name="id">Id of the Teaccher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher/Update/5</example>
        public ActionResult Update(int id)
        {
            try
            {
                Teacher SelectedTeacher = teacherDataController.FindTeacher(id);
                return View(SelectedTeacher);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Teacher");
            }

        }

        /// <summary>
        /// Receives a POST request containing information about an existing Teacher in the system, with new values. Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The updated first name of the Teacher</param>
        /// <param name="TeacherLname">The updated last name of the Teacher</param>
        /// <param name="EmployeeNumber">The updated employee number of the Teacher.</param>
        /// <param name="HireDate">The updated hire date of the Teacher.</param>
        /// <param name="Salary">The updated salary of the Teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the Teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/10
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Suyash",
        ///	"TeacherLname":"Kulkarni",
        ///	"EmployeeNumber":"T019",
        ///	"HireDate":"12/12/12",
        ///	"Salary":"100"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, string HireDate, string Salary)
        {
            try
            {
                Teacher TeacherInfo = new Teacher();
                TeacherInfo.TeacherFName = TeacherFname;
                TeacherInfo.TeacherLName = TeacherLname;
                TeacherInfo.EmployeeNumber = EmployeeNumber;
                TeacherInfo.HireDate = Convert.ToDateTime(HireDate);
                TeacherInfo.Salary = Convert.ToDouble(Salary);
                teacherDataController.UpdateTeacher(id, TeacherInfo);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Teacher");
            }
            return RedirectToAction("Show/" + id);
        }
        //GET : /Teacher/Error
        /// <summary>
        /// This window is for showing Teacher Specific Errors!
        /// </summary>
        public ActionResult Error()
        {
            return View();
        }

        //GET : /Teacher/List_JS
        /// <summary>
        /// This window is for showing Teacher's list using js
        /// </summary>
        public ActionResult List_JS()
        {
            return View();
        }

        /// <summary>
        /// Routes to a dynamically rendered "JS Update" Page. The "JS Update" page will utilize JavaScript to send an HTTP Request to the data access layer (/api/TeacherData/UpdateTeacher)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Update_JS(int id)
        {
            try
            {
                Teacher SelectedTeacher = teacherDataController.FindTeacher(id);
                return View(SelectedTeacher);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Error", "Home");
            }
        }
    }
}