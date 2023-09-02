using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankApplication.Models
{
    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustId { get; set; }
        [StringLength(80)]

        public string CustName { get; set; }
        public int YearOfBirth { get; set; }
        public int Cust_XSell_score { get; set; }
        public int AverageIncome { get; set; }
        public string Country { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<CurrentAccount> CustomerAccounts { get; set; }

        public Customer(int custId, string custName, int yearOfBirth, int cust_XSell_score, int averageIncome, string country)
        {
            CustId = custId;
            CustName = custName;
            YearOfBirth = yearOfBirth;
            Cust_XSell_score = cust_XSell_score;
            AverageIncome = averageIncome;
            Country = country;
            CustomerAccounts = new HashSet<CurrentAccount>();
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            return $"{CustId} + {CustName}";
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   CustId == customer.CustId &&
                   CustName == customer.CustName &&
                   YearOfBirth == customer.YearOfBirth &&
                   Cust_XSell_score == customer.Cust_XSell_score &&
                   AverageIncome == customer.AverageIncome &&
                   Country == customer.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustId, CustName, YearOfBirth, Cust_XSell_score, AverageIncome, Country);
        }
    }
}
