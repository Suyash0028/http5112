﻿// AJAX for Teacher Add can go in here
// This file is connected to the project via Shared/_Layout.cshtml


function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:44324/api/TeacherData/AddTeacher
	//with POST data of Teachername, salary, hiredate, etc.

	var URL = "http://localhost:44324/api/TeacherData/AddTeacher";

	var rq = new XMLHttpRequest();
	
	//Fecthed HTML Elements
	var TeacherFName = document.getElementById('TeacherFName').value;
	var TeacherLName = document.getElementById('TeacherLName').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var HireDate = document.getElementById('HireDate').value;
	var Salary = document.getElementById('Salary').value;

	//Fetched error msg tags
	var ErrorFirstNameMsg = document.getElementById("TeacherFName_Error");
	var ErrorLastNameMsg = document.getElementById("TeacherLName_Error");
	var ErrorEmployeeNumberMsg = document.getElementById("EmployeeNumber_Error");
	var ErrorHireDateMsg = document.getElementById("HireDate_Error");
	var ErrorSalaryMsg = document.getElementById("Salary_Error");


	//Checked if the firstname is empty or not
	if (TeacherFName == "" || TeacherFName == null || TeacherFName == undefined) {

		ErrorFirstNameMsg.innerText = "First Name is required field!!";
		ErrorFirstNameMsg.style.color = "Red";
		return false;
	}
	else {
		ErrorFirstNameMsg.innerText = "";
	}

	//Checked if the lastname is empty or not
	if (TeacherLName == "" || TeacherLName == null || TeacherLName == undefined) {

		ErrorLastNameMsg.innerText = "Last Name is required field!!";
		ErrorLastNameMsg.style.color = "Red";
		return false;
	}
	else {
		ErrorLastNameMsg.innerText = "";
	}

	//Checked if the employeenumber is empty or not
	if (EmployeeNumber == "" || EmployeeNumber == null || EmployeeNumber == undefined) {

		ErrorEmployeeNumberMsg.innerText = "Employee Number is required field!!";
		ErrorEmployeeNumberMsg.style.color = "Red";
		return false;
	}
	else {
		ErrorEmployeeNumberMsg.innerText = "";
	}

	//Checked if the hiredate is empty or not
	if (HireDate == "" || HireDate == null || HireDate == undefined) {

		ErrorHireDateMsg.innerText = "Hire Date is required field!!";
		ErrorHireDateMsg.style.color = "Red";
		return false;
	}
	else {
		ErrorHireDateMsg.innerText = "";
	}

	//Checked if the salary is empty or not
	if (Salary == "" || Salary == null || Salary == undefined) {

		ErrorSalaryMsg.innerText = "Salary is required field!!";
		ErrorSalaryMsg.style.color = "Red";
		return false;
	}
	else {
		ErrorSalaryMsg.innerText = "";
	}

	var TeacherData = {
		"TeacherFName": TeacherFName,
		"TeacherLName": TeacherLName,
		"EmployeeNumber": EmployeeNumber,
		"HireDate": HireDate,
		"Salary": Salary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 || rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.

			
		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}