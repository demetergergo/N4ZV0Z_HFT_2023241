let games = [];
let connection = null;

let gameIDtoUpdate = -1;

getdatagame();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:35916/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GameCreated", (user, message) => {
        getdatagame();
    });

    connection.on("GameDeleted", (user, message) => {
        getdatagame();
    });
    connection.on("GameUpdated", (user, message) => {
        getdatagame();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getdatagame() {
    await fetch('http://localhost:35916/game')
        .then(x => x.json())
        .then(y => {
            games = y;
            //console.log(games);
            displayGame();
        }); 
}

function displayGame() {
    document.getElementById('gameresultarea').innerHTML = "";
    games.forEach(t => {
        document.getElementById('gameresultarea').innerHTML +=
            "<tr><td>" + t.gameID + "</td><td>"
            + t.title + "</td><td>" +
            `<button type="button" onclick="removeGame(${t.gameID})">Delete</button>` +
            `<button type="button" onclick="showupdateGame(${t.gameID})">Update</button>`
            + "</td></tr>";
        console.log(t.title);
    })
}
function removeGame(id) {
    fetch('http://localhost:35916/game/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdateGame(id) {
    document.getElementById('titletoupdate').value = games.find(x => x['gameID'] == id)['title'];
    document.getElementById('updateformdiv').style.display = 'flex';
    gameIDtoUpdate = id;
}

function updateGame() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('titletoupdate').value;
    fetch('http://localhost:35916/game', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: name, gameID: gameIDtoUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => { console.error('Error:', error); });

}
function createGame() {
    let name = document.getElementById('title').value;
    fetch('http://localhost:35916/game', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: name })})
        .then(response => response)
        .then(data =>
        {
            console.log('Success:', data);
            getdatagame();
        })
        .catch((error) => { console.error('Error:', error); });
        
}