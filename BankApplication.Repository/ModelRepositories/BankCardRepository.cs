using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class BankCardRepository : Reposiotry<BankCard>, IRepositroy<BankCard>
    {
        public BankCardRepository(CustomerAccountsDbContext context) : base(context)
        {
        }

        public override BankCard Read(int id)
        {
            return context.BankCardDb.FirstOrDefault(x => x.CardId == id);
        }

        public override void Update(BankCard item)
        {
            var old = Read(item.CardId);
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
