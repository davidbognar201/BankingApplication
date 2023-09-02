using BankApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public class CustomerRepository : Reposiotry<Customer>, IRepositroy<Customer>
    {
        public CustomerRepository(CustomerAccountsDbContext context) : base(context)
        {
        }

        public override Customer Read(int id)
        {
            return context.CustomerDb.FirstOrDefault(x => x.CustId == id);
        }

        public override void Update(Customer item)
        {
            var old = Read(item.CustId);
            foreach (var property in old.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    property.SetValue(old, property.GetValue(item));
                }
                
            }
            context.SaveChanges();
        }
    }
}
