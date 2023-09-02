using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class CardByCurrencyInfo
    {
        public string AccountCurrencyType { get; set; }
        public string CardType { get; set; }
        public int CardCnt { get; set; }
        public CardByCurrencyInfo()
        {

        }

        public CardByCurrencyInfo(string accountCurrencyType, string cardType, int cardCnt)
        {
            AccountCurrencyType = accountCurrencyType;
            CardType = cardType;
            CardCnt = cardCnt;
        }

        public override string ToString()
        {
            return $"{AccountCurrencyType} -- {CardType} -- {CardCnt}";
        }

        public override bool Equals(object obj)
        {
            return obj is CardByCurrencyInfo info &&
                   AccountCurrencyType == info.AccountCurrencyType &&
                   CardType == info.CardType &&
                   CardCnt == info.CardCnt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountCurrencyType, CardType, CardCnt);
        }
    }
}
