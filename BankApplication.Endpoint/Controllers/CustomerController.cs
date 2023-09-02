using BankApplication.Endpoint.Services;
using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;
        IHubContext<SignalRHub> hub;

        public CustomerController(ICustomerLogic custLogic, IHubContext<SignalRHub> hub)
        {
            this.customerLogic = custLogic;
            this.hub = hub;
        }

        [HttpGet] 
        public IEnumerable<Customer> ReadAll()
        {
            return this.customerLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.customerLogic.Read(id);
        }
        [HttpPost] 
        public void Create([FromBody] Customer custToCreate)
        {

            this.customerLogic.Create(custToCreate);
            this.hub.Clients.All.SendAsync("CustomerCreated", custToCreate);

        }
        [HttpPut]
        public void Update([FromBody] Customer custToUpdate)
        {
            this.customerLogic.Update(custToUpdate);
            this.hub.Clients.All.SendAsync("CustomerUpdated", custToUpdate);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var custToDelete = this.customerLogic.Read(id);
            this.customerLogic.Delete(id);
            this.hub.Clients.All.SendAsync("CustomerDeleted", custToDelete);
        }
    }
}
