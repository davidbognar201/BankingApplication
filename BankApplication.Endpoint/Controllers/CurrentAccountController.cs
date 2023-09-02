using BankApplication.Endpoint.Services;
using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrentAccountController : ControllerBase
    {
        ICurrentAccountLogic accountLogic;
        IHubContext<SignalRHub> hub;

        public CurrentAccountController(ICurrentAccountLogic caLogic, IHubContext<SignalRHub> hub)
        {
            this.accountLogic = caLogic;
            this.hub = hub;
        }

        [HttpGet] 
        public IEnumerable<CurrentAccount> ReadAll()
        {
            return this.accountLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public CurrentAccount Read(int id)
        {
            return this.accountLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] CurrentAccount caToCreate)
        {
            this.accountLogic.Create(caToCreate);
            this.hub.Clients.All.SendAsync("CurrentAccountCreated", caToCreate);
        }
        [HttpPut]
        public void Update([FromBody] CurrentAccount value)
        {
            this.accountLogic.Update(value);
            this.hub.Clients.All.SendAsync("CurrentAccountUpdated", value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var caToDelete = this.accountLogic.Read(id);
            this.accountLogic.Delete(id);
            this.hub.Clients.All.SendAsync("CurrentAccountDeleted", caToDelete);
        }
    }
}
