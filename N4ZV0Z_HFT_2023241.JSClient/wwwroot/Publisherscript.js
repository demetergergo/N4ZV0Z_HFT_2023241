let publishers = [];

let publisherIDtoUpdate = -1;

getdatapublisher();

async function getdatapublisher() {
    await fetch('http://localhost:35916/publisher')
        .then(x => x.json())
        .then(y => {
            publishers = y;
            displayPublisher();
        });
}

function displayPublisher() {
    document.getElementById('publisherresultarea').innerHTML = "";
    publishers.forEach(t => {
        document.getElementById('publisherresultarea').innerHTML +=
            "<tr><td>" + t.publisherId + "</td><td>"
            + t.publisherName + "</td><td>" +
            `<button type="button" onclick="removePublisher(${t.publisherId})">Delete</button>` +
            `<button type="button" onclick="showupdatePublisher(${t.publisherId})">Update</button>`
            + "</td></tr>";
        console.log(t.publisherName);
    })
}
function removePublisher(id) {
    fetch('http://localhost:35916/publisher/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatapublisher();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdatePublisher(id) {
    document.getElementById('publishertitletoupdate').value = publishers.find(x => x['publisherId'] == id)['publisherName'];
    document.getElementById('publisherupdateformdiv').style.display = 'flex';
    publisherIDtoUpdate = id;
}

function updatePublisher() {
    document.getElementById('publisherupdateformdiv').style.display = 'none';
    let name = document.getElementById('publishertitletoupdate').value;
    fetch('http://localhost:35916/publisher', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { PublisherName: name, publisherId: publisherIDtoUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatapublisher();
        })
        .catch((error) => { console.error('Error:', error); });

}
function createPublisher() {
    let name = document.getElementById('publishertitle').value;
    fetch('http://localhost:35916/publisher', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { PublisherName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatapublisher();
        })
        .catch((error) => { console.error('Error:', error); });

}