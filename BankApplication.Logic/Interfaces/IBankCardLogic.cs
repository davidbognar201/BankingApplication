using BankApplication.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication.Logic
{
    public interface IBankCardLogic
    {
        void Create(BankCard item);
        void Delete(int id);
        BankCard Read(int id);
        IQueryable<BankCard> ReadAll();
        void Update(BankCard item);
        public IEnumerable<CardByCurrencyInfo> AggregateCardByCurrency();
        public IEnumerable<CardInfoByCountry> AggregateCardsByCountry(string cardType);
    }
}