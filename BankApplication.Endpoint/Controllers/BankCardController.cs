using BankApplication.Endpoint.Services;
using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankCardController : ControllerBase
    {
        IBankCardLogic bankCardLogic;
        IHubContext<SignalRHub> hub;

        public BankCardController(IBankCardLogic cardLogic, IHubContext<SignalRHub> hub)
        {
            this.bankCardLogic = cardLogic;
            this.hub = hub;
        }

        [HttpGet] 
        public IEnumerable<BankCard> ReadAll()
        {
            return this.bankCardLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public BankCard Read(int id)
        {
            return this.bankCardLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] BankCard cardToCreate)
        {
            this.bankCardLogic.Create(cardToCreate);
            this.hub.Clients.All.SendAsync("BankCardCreated", cardToCreate);
        }
        [HttpPut]
        public void Update([FromBody] BankCard value)
        {
            this.bankCardLogic.Update(value);
            this.hub.Clients.All.SendAsync("BankCardUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cardToDelete = this.bankCardLogic.Read(id);
            this.bankCardLogic.Delete(id);
            this.hub.Clients.All.SendAsync("BankCardDeleted", cardToDelete);
        }
    }
}
