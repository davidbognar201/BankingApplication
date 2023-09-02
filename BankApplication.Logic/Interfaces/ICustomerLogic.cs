using BankApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);
        public IEnumerable<CountryInfo> AggregateCustomersByCountry();
        public IEnumerable<Customer> GetCustomersByMinBalance(int min);
        public IEnumerable<Customer> GetCustomersByCardCount(int cardCnt);
    }
}