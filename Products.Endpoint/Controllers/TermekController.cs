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
    public class TermekController : ControllerBase
    {
        ILogic logic;
        private readonly IHubContext<SignalRHub> hub;

        public TermekController(ILogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Termek> GetAllProducts()
        {
            return this.logic.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Termek GetProduct(string id)
        {
            return this.logic.GetOneProduct(id);
        }

        [HttpPost]
        public void CreateProduct([FromBody] Termek value)
        {
            this.logic.AddProduct(value);
            hub.Clients.All.SendAsync("TermekCreated", value);
        }

        [HttpPut]
        public void PutProduct([FromBody] Termek value)
        {
            this.logic.UpdateProduct(value);
            hub.Clients.All.SendAsync("TermekUpdated", value);
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var deleteThisProduct = this.logic.GetOneProduct(id.ToString());
            this.logic.DeleteProduct(this.logic.GetAllProducts().First(x => x.TermekID == id));
            hub.Clients.All.SendAsync("TermekDeleted", deleteThisProduct);
        }
    }
}