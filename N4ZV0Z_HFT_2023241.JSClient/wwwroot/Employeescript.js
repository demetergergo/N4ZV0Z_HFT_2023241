let employees = [];

let employeeIDtoUpdate = -1;

getdataemployee();

async function getdataemployee() {
    await fetch('http://localhost:35916/employee')
        .then(x => x.json())
        .then(y => {
            employees = y;
            displayEmployee();
        });
}

function displayEmployee() {
    document.getElementById('employeeresultarea').innerHTML = "";
    employees.forEach(t => {
        document.getElementById('employeeresultarea').innerHTML +=
            "<tr><td>" + t.employeeId + "</td><td>"
            + t.employeeFirstName + "</td><td>" +
            `<button type="button" onclick="removeEmployee(${t.employeeId})">Delete</button>` +
            `<button type="button" onclick="showupdateEmployee(${t.employeeId})">Update</button>`
            + "</td></tr>";
        console.log(t.employeeFirstName);
    })
}
function removeEmployee(id) {
    fetch('http://localhost:35916/employee/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdataemployee();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdateEmployee(id) {
    document.getElementById('employeetitletoupdate').value = employees.find(x => x['employeeId'] == id)['employeeFirstName'];
    document.getElementById('employeeupdateformdiv').style.display = 'flex';
    employeeIDtoUpdate = id;
}

function updateEmployee() {
    document.getElementById('employeeupdateformdiv').style.display = 'none';
    let name = document.getElementById('employeetitletoupdate').value;
    fetch('http://localhost:35916/employee', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { employeeFirstName: name, employeeLastName: name, employeeId: employeeIDtoUpdate, employeeAge: 20})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdataemployee();
        })
        .catch((error) => { console.error('Error:', error); });

}
function createEmployee() {
    let name = document.getElementById('employeetitle').value;
    fetch('http://localhost:35916/employee', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { employeeFirstName: name, employeeLastName: name, employeeAge: 20, publisherID: 1 })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdataemployee();
        })
        .catch((error) => { console.error('Error:', error); });

}