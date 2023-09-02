using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class CurrentAccountRepository : Reposiotry<CurrentAccount>, IRepositroy<CurrentAccount>
    {
        public CurrentAccountRepository(CustomerAccountsDbContext context) : base(context)
        {
        }

        public override CurrentAccount Read(int id)
        {
            return context.CurrentAccountDb.FirstOrDefault(x => x.AccountId == id);
        }

        public override void Update(CurrentAccount item)
        {
            var old = Read(item.AccountId);
            foreach (var property in old.GetType().GetProperties())
            {
                try
                {
                    property.SetValue(old, property.GetValue(item));
                }
                catch
                {
                    property.SetValue(old, null);

                }
            }
            context.SaveChanges();
        }
    }
}
