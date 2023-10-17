let students = [];
const studentsUri = 'api/Students';
const gendersUri = 'api/Genders';

function getStudents() {
	fetch(studentsUri)
		.then(response => response.json())
		.then(data => displayStudents(data))
		.catch(error => console.error('Unable to get students.', error));
}

function displayGenderName(id, callback) {
	fetch(`${gendersUri}/${id}`)
		.then(data => {
			data.json().then(data => {
				callback(data);
			}
			);
		})
}
function getGenders() {
	fetch(gendersUri)
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
		editButton.setAttribute('onclick', `displayEditForm(${student.id})`);

		let deleteButton = button.cloneNode(false);
		deleteButton.innerText = 'Delete';
		deleteButton.setAttribute('onclick', `deleteStudent(${student.id})`);

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
		displayGenderName(student.genderId, function (gender) {
			let textNode6 = document.createTextNode(gender.name);
			td6.appendChild(textNode6);
		});

		let td7 = tr.insertCell(6);
		let textNode7 = document.createTextNode(student.noteSheetFile);
		td7.appendChild(textNode7);

		let td8 = tr.insertCell(7);
		td8.appendChild(editButton);

		let td9 = tr.insertCell(8);
		td9.appendChild(deleteButton);
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
	const addNoteSheetbox = document.getElementById('add-file');

	const student = {
		name: addNameTextbox.value.trim(),
		age: addAgeTextbox.value.trim(),
		email: addEmailTextbox.value.trim(),
		phoneNumber: addTelTextbox.value.trim(),
		additionalInfo: addInfoTextbox.value.trim(),
		teacherId: "1",
		parentId: "1",
		genderId: addGenderSelectbox.value,
		noteSheetFile: addNoteSheetbox.value.trim(),
	};
	 
	fetch(studentsUri, {
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
			addNoteSheetbox.value = "";
		})
		.catch(error => console.error('Unable to add student.', error));
}

function deleteStudent(id) {
	fetch(`${studentsUri}/${id}`, {
		method: 'DELETE'
	})
		.then(() => getStudents())
		.catch(error => console.error('Unable to delete student.', error));
}

function displayEditForm(id) {
	const student = students.find(student => student.id === id);

	document.getElementById('edit-id').value = student.id;
	document.getElementById('edit-name').value = student.name;
	document.getElementById('edit-information').value = student.additionalInfo;
	document.getElementById('edit-age').value = student.age;
	document.getElementById('edit-email').value = student.email; 
	document.getElementById('edit-phone').value = student.phoneNumber; 
	document.getElementById('edit-gender').value = student.genderId;
	document.getElementById('editStudent').style.display = 'block';
}

function updateStudent() {
	const editIdTextbox = document.getElementById('edit-id');
	const editNameTextbox = document.getElementById('edit-name');
	const editInfoTextbox = document.getElementById('edit-information');
	const editAgeTextbox = document.getElementById('edit-age');
	const editEmailTextbox = document.getElementById('edit-email');
	const editTelTextbox = document.getElementById('edit-phone');
	const editGenderSelectbox = document.getElementById('edit-gender');
	const editNoteShetTextbox = document.getElementById('edit-file');

	const student = {
		id: editIdTextbox.value.trim(),
		name: editNameTextbox.value.trim(),
		age: editAgeTextbox.value.trim(),
		email: editEmailTextbox.value.trim(),
		phoneNumber: editTelTextbox.value.trim(),
		additionalInfo: editInfoTextbox.value.trim(),
		teacherId: "1",
		parentId: "1",
		genderId: editGenderSelectbox.value,
		noteSheetFile: editNoteShetTextbox.value.trim(),
	};

	fetch(`${studentsUri}/${student.id}`, {
		method: 'PUT',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(student)
	})
		.then(() => getStudents())
		.catch(error => console.error('Unable to update student.', error));
	closeInput();
	return false;
}

function closeInput() {
	document.getElementById('editStudent').style.display = 'none';
}