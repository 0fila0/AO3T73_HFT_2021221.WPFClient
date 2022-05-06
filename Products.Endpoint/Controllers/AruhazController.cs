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
    public class AruhazController : ControllerBase
    {
        ILogic logic;
        private readonly IHubContext<SignalRHub> hub;

        public AruhazController(ILogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Aruhaz> GetAllShops()
        {
            return this.logic.GetAllShops();
        }

        [HttpGet("{id}")]
        public Aruhaz GetShop(string id)
        {
            return this.logic.GetOneShop(id);
        }

        [HttpPost]
        public void CreateShop([FromBody] Aruhaz value)
        {
            this.logic.AddShop(value);
            hub.Clients.All.SendAsync("AruhazCreated", value);
        }

        [HttpPut]
        public void PutShop([FromBody] Aruhaz value)
        {
            this.logic.UpdateShop(value);
            hub.Clients.All.SendAsync("AruhazUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteShop(string id)
        {
            var deleteThisShop = this.logic.GetOneShop(id);
            this.logic.DeleteShop(this.logic.GetAllShops().First(x => x.AruhazNeve == id));
            hub.Clients.All.SendAsync("AruhazDeleted", deleteThisShop);
        }
    }
}
