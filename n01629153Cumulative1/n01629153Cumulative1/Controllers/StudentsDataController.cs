using MySql.Data.MySqlClient;
using n01629153Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace n01629153Cumulative1.Controllers
{
    public class StudentsDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext SchoolDB = new SchoolDbContext();

        //This Controller Will access the Students table of our School database.
        /// <summary>
        /// Returns a data of Students
        /// </summary>
        /// <example>GET api/StudentsData/ListStudentsData</example>
        /// <returns>
        /// This function will return the data from the Students table (Student First Name, Student Last Name, Student Number and Enrol Date)
        /// </returns>
        [HttpGet]
        [Route("api/StudentsData/ListStudentsData")]
        public IEnumerable<string> ListStudentsData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader StudentsResultSet = cmd.ExecuteReader();

            //Create an empty list for Students data
            List<string> StudentsData = new List<string> { };

            //Loop Through Each Row the Result Set
            while (StudentsResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string StudentsRecord = "Name: " + StudentsResultSet["studentfname"] + " " + StudentsResultSet["studentlname"] + " " + "Students Number: " + StudentsResultSet["studentnumber"] + " " + "Enroll Date:  " + StudentsResultSet["enroldate"];

                //Add the Students data to the List
                StudentsData.Add(StudentsRecord);

            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo Students data
            return StudentsData;
        }

        [HttpGet]
        [Route("api/StudentsData/FetchStudentsData")]
        public IEnumerable<Students> FetchStudentsData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Created a variable for the models list
            List<Students> Students = new List<Students> { };

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from students";

            //Gather Result Set of Query into a variable
            MySqlDataReader StudentsResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (StudentsResultSet.Read())
            {
                //Created a variable for the model
                Students StudentsDataModel = new Students { };

                //Added the data from the result set to the model
                StudentsDataModel.StudentFName = StudentsResultSet["studentfname"].ToString();
                StudentsDataModel.StudentLName = StudentsResultSet["studentlname"].ToString();
                StudentsDataModel.StudentNumber = StudentsResultSet["studentnumber"].ToString();
                StudentsDataModel.EnrollDate = Convert.ToDateTime(StudentsResultSet["enroldate"]);
           

                Students.Add(StudentsDataModel);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo Students data
            return Students;
        }
    }
}
