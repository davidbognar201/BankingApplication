using BankApplication.Models;
using BankApplication.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BankApplication.Logic
{
    public class CustomerLogic : ICustomerLogic
    {

        IRepositroy<Customer> customerRepository;

        public CustomerLogic(IRepositroy<Customer> repository)
        {
            this.customerRepository = repository;
        }

        public void Create(Customer item)
        {
            string invalidCharacters = "0123456789$@<>";
            if (item != null)
            {
                if (item.CustName.Length >= 2 && !(item.CustName.Any(c => invalidCharacters.Contains(c))))
                {
                    this.customerRepository.Create(item);
                }
                else throw new ArgumentException("The given name is not valid");
            }else throw new ArgumentNullException();
            




        }

        public void Delete(int id)
        {
            var customer = this.customerRepository.Read(id);
            if (customer != null)
            {
                this.customerRepository.Delete(id);
                
            }
            else throw new ArgumentException("The given customer does not exist");


        }

        public Customer Read(int id)
        {
            var customer = this.customerRepository.Read(id);
            if (customer == null)
            {
                throw new ArgumentException("The given customer does not exist");
            }
            return customer;
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.customerRepository.ReadAll();
        }

        public void Update(Customer item)
        {
            this.customerRepository.Update(item);
        }
        // NON_CRUDs
        public IEnumerable<CountryInfo> AggregateCustomersByCountry()
        {

            return (from x in customerRepository.ReadAll().SelectMany(x => x.CustomerAccounts)
                   group x by x.AccountOwner.Country into grp
                   orderby grp.Average(x => x.AccountBalance)
                   select new CountryInfo()
                   {
                       CountryName = grp.Key,
                       CustomerCount = grp.Select(x => x.OwnerId).Distinct().Count(),
                       AvgBalance = grp.Average(x => x.AccountBalance)
                   }).ToList();

        }
        public IEnumerable<Customer> GetCustomersByMinBalance(int min)
        {
            return from x in customerRepository.ReadAll()
                   let maxBalance = x.CustomerAccounts.Max(x => x.AccountBalance)
                   where maxBalance >= min
                   select x;
        }
        public IEnumerable<Customer> GetCustomersByCardCount(int cardCnt)
        {
            return from x in customerRepository.ReadAll()
                   let custCardCnt = x.CustomerAccounts
                                        .SelectMany(x => x.AttachedCards)
                                        .Count()
                   where custCardCnt > cardCnt
                   select x;
        }
        

    }

}
