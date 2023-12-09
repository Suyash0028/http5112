// AJAX for Teacher Add can go in here
// This file is connected to the project via Shared/_Layout.cshtml


function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:44388/api/TeacherData/AddTeacher
	//with POST data of Teachername, salary, hiredate, etc.

	var URL = "https://localhost:44388/api/TeacherData/AddTeacher";

	var rq = new XMLHttpRequest();
	//Fecthed HTML Elements
	var TeacherFName = document.getElementById('TeacherFName').value;
	var TeacherLName = document.getElementById('TeacherLName').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var HireDate = document.getElementById('HireDate').value;
	var Salary = document.getElementById('Salary').value;

	
	//check for validation straight away
	var IsValid = ValidateTeacher(TeacherFName, TeacherLName, EmployeeNumber, HireDate, Salary);
	if (!IsValid) return;

	var TeacherData = {
		TeacherFName: TeacherFName,
		TeacherLName: TeacherLName,
		EmployeeNumber: EmployeeNumber,
		HireDate: HireDate,
		Salary: Salary
	};

	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");

	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));
	alert("Teacher Added");
	window.location.href = "https://localhost:44388/Teacher/List";
}

function ValidateTeacher(TeacherFName, TeacherLName, EmployeeNumber, HireDate, Salary) {
	var isValid = true;
	
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
		isValid = false;
	}
	else {
		ErrorFirstNameMsg.innerText = "";
	}

	//Checked if the lastname is empty or not
	if (TeacherLName == "" || TeacherLName == null || TeacherLName == undefined) {

		ErrorLastNameMsg.innerText = "Last Name is required field!!";
		ErrorLastNameMsg.style.color = "Red";
		isValid = false;
	}
	else {
		ErrorLastNameMsg.innerText = "";
	}

	//Checked if the employeenumber is empty or not
	if (EmployeeNumber == "" || EmployeeNumber == null || EmployeeNumber == undefined) {

		ErrorEmployeeNumberMsg.innerText = "Employee Number is required field!!";
		ErrorEmployeeNumberMsg.style.color = "Red";
		isValid = false;
	}
	else {
		ErrorEmployeeNumberMsg.innerText = "";
	}

	//Checked if the hiredate is empty or not
	if (HireDate == "" || HireDate == null || HireDate == undefined) {

		ErrorHireDateMsg.innerText = "Hire Date is required field!!";
		ErrorHireDateMsg.style.color = "Red";
		isValid = false;
	}
	else {
		ErrorHireDateMsg.innerText = "";
	}

	//Checked if the salary is empty or not
	if (Salary == "" || Salary == null || Salary == undefined) {

		ErrorSalaryMsg.innerText = "Salary is required field!!";
		ErrorSalaryMsg.style.color = "Red";
		isValid = false;
	}
	else {
		if (isNaN(Salary)) {
			ErrorSalaryMsg.innerText = "Please enter proper value for salary field!!";
			ErrorSalaryMsg.style.color = "Red";
			isValid = false;
		}
		else {
			ErrorSalaryMsg.innerText = "";
		}
	}
	return isValid;
}

// This function attaches a timer object to the input window.
// When the timer expires (300ms), the search executes.
// Prevents a search on each key up for fast typers.
function _ListTeachers(d) {

	if (d.timer) clearTimeout(d.timer);
	d.timer = setTimeout(function () { ListTeachers(d.value); }, 300);
}
function ListTeachers(SearchKey) {

	var URL = "https://localhost:44388/api/TeacherData/ListTeachers/" + SearchKey;

	var rq = new XMLHttpRequest();
	rq.open("GET", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	//POST information sent through the .send() method
	rq.send();
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished


			var teachers = JSON.parse(rq.responseText)
			var listTeachers = document.getElementById("listteachers");
			listTeachers.innerHTML = "";

			//renders content for each author pulled from the API call
			for (var i = 0; i < teachers.length; i++) {
				var row = document.createElement("div");
				row.classList = "listitem row";
				var col = document.createElement("col");
				col.classList = "col-md-12";
				var link = document.createElement("a");
				link.href = "/Teacher/Show/" + teachers[i].TeacherId;
				link.innerHTML = teachers[i].TeacherFName + " " + teachers[i].TeacherLName;

				col.appendChild(link);
				row.appendChild(col);
				listTeachers.appendChild(row);

			}
		}

	}
	
}

function UpdateTeacher(TeacherId) {

	//Fecthed HTML Elements
	var TeacherFName = document.getElementById('TeacherFName').value;
	var TeacherLName = document.getElementById('TeacherLName').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var HireDate = document.getElementById('HireDate').value;
	var Salary = document.getElementById('Salary').value;


	//check for validation straight away
	var IsValid = ValidateTeacher(TeacherFName, TeacherLName, EmployeeNumber, HireDate, Salary);
	if (!IsValid) return;

	//goal: send a request which looks like this:
	//POST : "https://localhost:44388/api/TeacherData/UpdateTeacher/{id}
	//with POST data of teachername,salary, hiredate etc.

	var URL = "https://localhost:44388/api/TeacherData/UpdateTeacher/" + TeacherId;

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?



	var TeacherData = {
		TeacherFName: TeacherFName,
		TeacherLName: TeacherLName,
		EmployeeNumber: EmployeeNumber,
		HireDate: HireDate,
		Salary: Salary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

	alert("Teacher Updated");
	window.location.href = "https://localhost:44388/Teacher/List_JS";
}