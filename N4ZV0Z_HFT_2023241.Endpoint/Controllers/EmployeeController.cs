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
    public class EmployeeController : ControllerBase
    {

        IEmployeeLogic logic;
        IHubContext<SignalRHub> hub;

        public EmployeeController(IEmployeeLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Employee> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Employee Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Employee value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("EmployeeCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Employee value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("EmployeeUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employeeToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("EmployeeDeleted", employeeToDelete);
        }
    }
}
