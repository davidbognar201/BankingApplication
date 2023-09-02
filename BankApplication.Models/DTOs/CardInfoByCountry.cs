using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class CardInfoByCountry
    {
        public string CountryName { get; set; }
        public int AllCardAmount { get; set; }

        public override string ToString()
        {
            return $"{CountryName}: {AllCardAmount}" ;
        }
        public override bool Equals(object obj)
        {
            return obj is CardInfoByCountry country &&
                   CountryName == country.CountryName &&
                   AllCardAmount == country.AllCardAmount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CountryName, AllCardAmount);
        }
    }
}
