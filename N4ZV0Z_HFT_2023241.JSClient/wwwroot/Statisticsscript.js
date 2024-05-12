async function getStatistics() {
    await getDevelopersCountAtGames()
}
getDevelopersCountAtGames()

let DeveloperCountAtGamesStat = []

async function getDevelopersCountAtGames() {
    await fetch('http://localhost:35916/stat/developerscountatgames')
        .then(x => x.json())
        .then(y => {
            DeveloperCountAtGamesStat = y
            console.log(DeveloperCountAtGamesStat)
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