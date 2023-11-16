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
    public class ClassesDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext SchoolDB = new SchoolDbContext();

        //This Controller Will access the Classes table of our School database.
        /// <summary>
        /// Returns a data of Classes
        /// </summary>
        /// <example>GET api/ClassesData/ListClassesData</example>
        /// <returns>
        /// This function will return the data from the Classes table (Class Code, Teachers Id, Start Date, Finish Date and Class Name)
        /// </returns>
        [HttpGet]
        [Route("api/ClassesData/ListClassesData")]
        public IEnumerable<string> ListClassesData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY to fetch data from classes table
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ClassesResultSet = cmd.ExecuteReader();

            //Create an empty list for Classes data
            List<string> ClassesData = new List<string> { };

            //Loop Through Each Row the Result Set
            while (ClassesResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                string ClassesRecord = "Class Code: " + ClassesResultSet["classcode"] + " "+ "Teacher ID: " + ClassesResultSet["teacherid"] + " " + "Classes Start Date: " + ClassesResultSet["startdate"] + " " + "Finish Date:  " + ClassesResultSet["finishdate"];

                //Add the Classes data to the List
                ClassesData.Add(ClassesRecord);

            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo Classes data
            return ClassesData;
        }

        //This Controller Will access the Classes table of our School database.
        /// <summary>
        /// Reeturns the data as an object 
        /// </summary>
        /// <example>GET api/ClassesData/FetchClassesData</example>
        /// <returns>
        /// This function will return the data from the Classes table in specified format
        /// </returns>
        [HttpGet]
        [Route("api/ClassesData/FetchClassesData")]
        public IEnumerable<Classes> FetchClassesData()
        {
            //Create an instance of a connection
            MySqlConnection Conn = SchoolDB.AccessDatabase();

            //Created a variable for the models list
            List<Classes> Classes = new List<Classes> { };

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from classes";

            //Gather Result Set of Query into a variable
            MySqlDataReader ClassesResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (ClassesResultSet.Read())
            {

                //Created a variable for the model
                Classes ClassesDataModel = new Classes { };

                //Added the data from the result set to the model
                ClassesDataModel.ClassName = ClassesResultSet["classname"].ToString();
                ClassesDataModel.TeacherId = Convert.ToInt32(ClassesResultSet["teacherid"]);
                ClassesDataModel.ClassCode = ClassesResultSet["classcode"].ToString();
                ClassesDataModel.StartDate = Convert.ToDateTime(ClassesResultSet["startdate"]);
                ClassesDataModel.FinishDate = Convert.ToDateTime(ClassesResultSet["finishdate"]);

                Classes.Add(ClassesDataModel);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the collection fo Classes data
            return Classes;
        }
    }
}
