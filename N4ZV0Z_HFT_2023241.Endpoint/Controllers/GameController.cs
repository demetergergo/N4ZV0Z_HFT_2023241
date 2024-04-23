using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using N4ZV0Z_HFT_2023241.Endpoint.Services;
using N4ZV0Z_HFT_2023241.Logic;
using N4ZV0Z_HFT_2023241.Models;
using System.Collections.Generic;

namespace N4ZV0Z_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        IGameLogic logic;
        IHubContext<SignalRHub> hub;

        public GameController(IGameLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Game value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("GameCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Game value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("GameUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("GameDeleted", gameToDelete);
            
        }
    }
}
