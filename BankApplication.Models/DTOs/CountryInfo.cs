using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class CountryInfo
    {
        public string CountryName { get; set; }
        public int CustomerCount { get; set; }
        public double AvgBalance { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CountryInfo info &&
                   CountryName == info.CountryName &&
                   CustomerCount == info.CustomerCount &&
                   AvgBalance == info.AvgBalance;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CountryName, CustomerCount, AvgBalance);
        }

        public override string ToString()
        {
            return $"{CountryName} -- {CustomerCount} -- {AvgBalance}";
        }

    }
}
