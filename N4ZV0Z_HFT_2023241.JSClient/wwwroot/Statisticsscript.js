async function getStatistics() {
    await getDevelopersCountAtGames()
    await getMostIncomeGamePerPublisher()
    await getPublishersByAverageRating()
}
getDevelopersCountAtGames()

let DeveloperCountAtGamesStat = []

async function getDevelopersCountAtGames() {
    await fetch('http://localhost:35916/stat/developerscountatgames')
        .then(x => x.json())
        .then(y => {
            DeveloperCountAtGamesStat = y
            displayDevelopersCountAtGames()
        })
}

function displayDevelopersCountAtGames() {
    document.querySelector('#resultcrud1').innerHTML = ""
    DeveloperCountAtGamesStat.forEach(t => {
        document.querySelector('#resultcrud1').innerHTML +=
            `<tr>
          <td>${t.gameTitle}</td>
          <td>${t.developerCount}</td>
          </tr>`
    })
}

//MostIncomeGamePerPublisher
getMostIncomeGamePerPublisher()

let MostIncomeGamePerPublisherStat = []

async function getMostIncomeGamePerPublisher() {
    await fetch('http://localhost:35916/stat/mostincomegameperpublisher')
        .then(x => x.json())
        .then(y => {
            MostIncomeGamePerPublisherStat = y
            displayMostIncomeGamePerPublisher()
        })
}

function displayMostIncomeGamePerPublisher() {
    document.querySelector('#resultcrud2').innerHTML = ""
    MostIncomeGamePerPublisherStat.forEach(t => {
        document.querySelector('#resultcrud2').innerHTML +=
            `<tr>
          <td>${t.publisherName}</td>
          <td>${t.gameName}</td>
          <td>${t.gameIncome}</td>
          </tr>`
    })
}

//PublishersByAverageRating
getPublishersByAverageRating()

let PublishersByAverageRatingStat = []

async function getPublishersByAverageRating() {
    await fetch('http://localhost:35916/stat/publishersbyaveragerating')
        .then(x => x.json())
        .then(y => {
            PublishersByAverageRatingStat = y
            console.log(PublishersByAverageRatingStat)
            displayPublishersByAverageRating()
        })
}

function displayPublishersByAverageRating() {
    document.querySelector('#resultcrud3').innerHTML = ""
    PublishersByAverageRatingStat.forEach(t => {
        document.querySelector('#resultcrud3').innerHTML +=
            `<tr>
          <td>${t.PublisherName}</td>
          <td>${t.ratingAverage}</td>
          </tr>`
    })
}