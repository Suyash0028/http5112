using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using n01629153Cumulative1.Models;

namespace n01629153Cumulative1.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext SchoolDB = new SchoolDbContext();

        //This Controller Will access the teachers table of our School database.
        /// <summary>
        /// Returns a data of teacher
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachersData</example>
        /// <returns>
        /// This function will return the data from the teachers table (first names, last names, employee number, hire date and salary)
        /// </returns>
        [HttpGet]
        [Route("api/TeachersData/ListTeachersData")]
        public IEnumerable<string> ListTeachersData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list for teachers data
            List<string> TeachersData = new List<string> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string TeacherName = "Name: " + ResultSet["teacherfname"] + " " + ResultSet["teacherlname"] + " " + "Employee Number: " + ResultSet["employeenumber"] + " " + "Hire Date:  " + ResultSet["hiredate"] + " " + "Salary: " + ResultSet["salary"];
               
                //Add the teachers data to the List
                TeachersData.Add(TeacherName);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo teachers data
            return TeachersData;
        }

        [HttpGet]
        public IEnumerable<Teacher> FetchTeachersData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Created a variable for the models list
            List<Teacher> teachers = new List<Teacher>();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Created a variable for the model
                Teacher DataModel = new Teacher();

                //Added the data from the result set to the model
                DataModel.TeacherFName = ResultSet["teacherfname"].ToString();
                DataModel.TeacherLName = ResultSet["teacherlname"].ToString();
                DataModel.EmployeeNumber = ResultSet["employeenumber"].ToString();
                DataModel.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                DataModel.Salary = Convert.ToDouble(ResultSet["salary"]);

                teachers.Add(DataModel);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo teachers data
            return teachers;
        }

    }
}