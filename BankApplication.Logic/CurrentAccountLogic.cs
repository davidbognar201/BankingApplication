using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Repository;
using BankApplication.Models;
using System.Net.Cache;

namespace BankApplication.Logic
{
    public class CurrentAccountLogic : ICurrentAccountLogic
    {
        IRepositroy<CurrentAccount> currentAccountRepository;

        public CurrentAccountLogic(IRepositroy<CurrentAccount> repositroy)
        {
            this.currentAccountRepository = repositroy;
        }

        public void Create(CurrentAccount item)
        {
            if (item != null)
            {
                this.currentAccountRepository.Create(item);
            }
            else throw new ArgumentNullException();
            
        }

        public void Delete(int id)
        {
            var account = this.currentAccountRepository.Read(id);
            if (account != null)
            {
                this.currentAccountRepository.Delete(id);

            }
            else throw new ArgumentException("The given account does not exist");
        }

        public CurrentAccount Read(int id)
        {
            var currentaccount = this.currentAccountRepository.Read(id);
            if (currentaccount == null)
            {
                throw new ArgumentException("The given account does not exist");
            }
            return currentaccount;
        }

        public IQueryable<CurrentAccount> ReadAll()
        {
            return this.currentAccountRepository.ReadAll();
        }

        public void Update(CurrentAccount item)
        {
            this.currentAccountRepository.Update(item);
        }



    }

}

