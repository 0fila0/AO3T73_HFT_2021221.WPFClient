using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Products.Data.Models;
using Products.Endpoint.Services;
using Products.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GyartoController : ControllerBase
    {
        ILogic logic;
        private readonly IHubContext<SignalRHub> hub;
        public GyartoController(ILogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Gyarto> GetAllManufacturers()
        {
            return this.logic.GetAllManufacturers();
        }

        [HttpGet("{id}")]
        public Gyarto GetManufacturer(string id)
        {
            return this.logic.GetOneManufacturer(id);
        }

        [HttpPost]
        public void CreateManufacturer([FromBody] Gyarto value)
        {
            this.logic.AddManufacturer(value);
            hub.Clients.All.SendAsync("GyartoCreated", value);
        }

        [HttpPut]
        public void PutManufacturer([FromBody] Gyarto value)
        {
            this.logic.UpdateManufacturer(value);
            hub.Clients.All.SendAsync("GyartoUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteManufacturer(string id)
        {
            var deleteThisManufacturer = this.logic.GetOneManufacturer(id);
            this.logic.DeleteManufacturer(this.logic.GetAllManufacturers().First(x => x.GyartoNeve == id));
            hub.Clients.All.SendAsync("GyartoDeleted", deleteThisManufacturer);
        }
    }
}
