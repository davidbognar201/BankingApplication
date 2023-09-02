using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Repository
{
    public abstract class Reposiotry<T> : IRepositroy<T> where T : class
    {
        protected CustomerAccountsDbContext context;
        public Reposiotry(CustomerAccountsDbContext context)
        {
            this.context = context;
        }

        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            context.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract void Update(T item);
        public abstract T Read(int id);
    }
}
