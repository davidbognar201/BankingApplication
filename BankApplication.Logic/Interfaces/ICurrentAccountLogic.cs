using BankApplication.Models;
using System.Linq;

namespace BankApplication.Logic
{
    public interface ICurrentAccountLogic
    {
        void Create(CurrentAccount item);
        void Delete(int id);
        CurrentAccount Read(int id);
        IQueryable<CurrentAccount> ReadAll();
        void Update(CurrentAccount item);
    }
}