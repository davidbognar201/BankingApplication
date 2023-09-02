using BankApplication.Logic;
using BankApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {

        IBankCardLogic cardLogic;
        ICustomerLogic customerLogic;
        ICurrentAccountLogic currentAccountLogic;

        public NonCrudController(IBankCardLogic cardLogic, ICustomerLogic customerLogic, ICurrentAccountLogic currentAccountLogic)
        {
            this.cardLogic = cardLogic;
            this.customerLogic = customerLogic;
            this.currentAccountLogic = currentAccountLogic;
        }

        [HttpGet]
        public IEnumerable<CardByCurrencyInfo> AggregateCardByCurrency()
        {
            return cardLogic.AggregateCardByCurrency();
        }
        [HttpGet]
        public IEnumerable<CountryInfo> AggregateCustomersByCountry()
        {
            return customerLogic.AggregateCustomersByCountry();
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomersByMinBalance([FromQuery]int min)
        {
            return customerLogic.GetCustomersByMinBalance(min);
        }

        [HttpGet]
        public IEnumerable<CardInfoByCountry> AggregateCardsByCountry([FromQuery] string cardType)
        {
            return cardLogic.AggregateCardsByCountry(cardType);
        }
        [HttpGet]
        public IEnumerable<Customer> GetCustomersByCardCount([FromQuery] int cardCnt)
        {
            return customerLogic.GetCustomersByCardCount(cardCnt);
        }

        
    }
}
