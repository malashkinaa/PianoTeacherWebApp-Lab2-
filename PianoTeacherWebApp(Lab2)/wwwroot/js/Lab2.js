let students = [];

function getStudents() {
	fetch('api/Students')
		.then(response => response.json())
		.then(data => displayStudents(data))
		.catch(error => console.error('Unable to get students.', error));
}

function getGenders() {
	fetch('api/Genders')
		.then(response => response.json())
		.then(data => {
			displayGenders(data, 'edit-gender');
			displayGenders(data, 'add-gender');
		})
		.catch(error => console.error('Unable to get genders.', error));
}

function displayGenders(data, selectId) {
	const genderList = document.getElementById(selectId);
	for (const gender of data) {
		var opt = document.createElement("option");
		opt.value = gender.id;
		opt.textContent = gender.name;
		genderList.add(opt);
	}
}

function displayStudents(data) {
	const tBody = document.getElementById('students');
	tBody.innerHTML = "";

	const button = document.createElement('button');

	data.forEach(student => {
		let editButton = button.cloneNode(false);
		editButton.innerText = 'Edit';
		editButton.setAttribute('onclick', 'displayEditForm(${student.id})');

		let deleteButton = button.cloneNode(false);
		deleteButton.innerText = 'Delete';
		deleteButton.setAttribute('onclick', 'deleteStudent(${student.id})');

		let tr = tBody.insertRow();

		let td1 = tr.insertCell(0);
		let textNode1 = document.createTextNode(student.name);
		td1.appendChild(textNode1);

		let td2 = tr.insertCell(1);
		let textNode2 = document.createTextNode(student.additionalInfo);
		td2.appendChild(textNode2);

		let td3 = tr.insertCell(2);
		let textNode3 = document.createTextNode(student.age);
		td3.appendChild(textNode3);

		let td4 = tr.insertCell(3);
		let textNode4 = document.createTextNode(student.email);
		td4.appendChild(textNode4);

		let td5 = tr.insertCell(4);
		let textNode5 = document.createTextNode(student.phoneNumber);
		td5.appendChild(textNode5);

		let td6 = tr.insertCell(5);
		let textNode6 = document.createTextNode(student.genderId);
		td6.appendChild(textNode6);

		let td7 = tr.insertCell(6);
		td7.appendChild(editButton);

		let td8 = tr.insertCell(7);
		td8.appendChild(deleteButton);
	});

	students = data;
}

function addStudent() {
	const addNameTextbox = document.getElementById('add-name');
	const addInfoTextbox = document.getElementById('add-information');
	const addAgeTextbox = document.getElementById('add-age');
	const addEmailTextbox = document.getElementById('add-email');
	const addTelTextbox = document.getElementById('add-phone');
	const addGenderSelectbox = document.getElementById('add-gender');

	const student = {
		name: addNameTextbox.value.trim(),
		age: addAgeTextbox.value.trim(),
		email: addEmailTextbox.value.trim(),
		phoneNumber: addTelTextbox.value.trim(),
		additionalInfo: addInfoTextbox.value.trim(),
		teacherId: "1",
		parentId: "1",
		genderId: addGenderSelectbox.value,
	};

	fetch('api/Students', {
		method: 'POST',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(student)
	})
		.then(() => {
			getStudents();
			addNameTextbox.value = "";
			addInfoTextbox.value = "";
			addAgeTextbox.value = "";
			addEmailTextbox.value = "";
			addTelTextbox.value = "";
		})
		.catch(error => console.error('Unable to add student.', error));
}

