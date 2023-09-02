using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApplication.Repository;
using BankApplication.Models;
using System.Globalization;


namespace BankApplication.Logic
{
    public class BankCardLogic : IBankCardLogic
    {
        IRepositroy<BankCard> bankCardReposiotry;

        public BankCardLogic(IRepositroy<BankCard> repositroy)
        {
            this.bankCardReposiotry = repositroy;
        }

        public void Create(BankCard item)
        {
            string allowedChars = "0123456789-";
            if (item != null)
            {
                if (item.CardNumber.Length <= 19 && item.CardNumber.All(allowedChars.Contains))
                {
                    this.bankCardReposiotry.Create(item);
                }
                else throw new ArgumentException("The given card number is invalid");

            }
            else throw new ArgumentNullException();
            
        }

        public void Delete(int id)
        {
            var card = this.bankCardReposiotry.Read(id);
            if (card != null)
            {
                this.bankCardReposiotry.Delete(id);

            }
            else throw new ArgumentException("The given card does not exist");
        }

        public BankCard Read(int id)
        {
            var bankcard = this.bankCardReposiotry.Read(id);
            if (bankcard == null)
            {
                throw new ArgumentException("The given card does not exist");
            }
            return bankcard;
        }

        public IQueryable<BankCard> ReadAll()
        {
            return this.bankCardReposiotry.ReadAll();
        }

        public void Update(BankCard item)
        {
            this.bankCardReposiotry.Update(item);
        }

        // NON_CRUD Methods

        public IEnumerable<CardByCurrencyInfo> AggregateCardByCurrency()
        {
            return from x in bankCardReposiotry.ReadAll()
                   group x by new
                   {
                       x.AttachedAccount.AccountCurrency,
                       x.Type
                   } into cardGrp
                   select new CardByCurrencyInfo
                   {
                       AccountCurrencyType = cardGrp.Key.AccountCurrency.ToString(),
                       CardType = cardGrp.Key.Type.ToString(),
                       CardCnt = cardGrp.Count()

                   };
        }

        public IEnumerable<CardInfoByCountry> AggregateCardsByCountry(string cardType)
        {
            if (cardType == "ALL")
            {
                return from x in bankCardReposiotry.ReadAll()
                       group x by x.AttachedAccount.AccountOwner.Country into grp
                       select new CardInfoByCountry
                       {
                           CountryName = grp.Key,
                           AllCardAmount = grp.Count()
                       };
            }
            else if (cardType.ToUpper().Trim() == "VISA" || cardType.ToUpper().Trim() == "MASTERCARD")
            {
                return from x in bankCardReposiotry.ReadAll()
                       where x.Type.ToUpper().Trim() == cardType.ToUpper().Trim()
                       group x by x.AttachedAccount.AccountOwner.Country into grp
                       select new CardInfoByCountry
                       {
                           CountryName = grp.Key,
                           AllCardAmount = grp.Count()
                       };
            }
            else throw new ArgumentException("The given card type does not exist.");

        }
    }


}
