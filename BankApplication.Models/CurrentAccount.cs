using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankApplication.Models
{
    public class CurrentAccount
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        public int AccountBalance { get; set; }
        public string AccountNumber { get; set; }

        public string AccountCurrency { get; set; }
        public int OwnerId { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<BankCard> AttachedCards { get; set; }
        public virtual Customer AccountOwner { get; set; }

        public CurrentAccount(int accountId, int accountBalance, string accountCurrency, string accountNumber, int ownerId)
        {
            AccountId = accountId;
            AccountBalance = accountBalance;
            AccountNumber = accountNumber;
            AccountCurrency = accountCurrency;
            OwnerId = ownerId;
            AttachedCards = new HashSet<BankCard>();
        }

        public CurrentAccount()
        {

        }

        public override string ToString()
        {
            return $"{AccountId} -- {AccountBalance} ({AccountCurrency}) -- {AccountOwner.CustName}";
        }

        public override bool Equals(object obj)
        {
            return obj is CurrentAccount account &&
                   AccountId == account.AccountId &&
                   AccountBalance == account.AccountBalance &&
                   AccountCurrency == account.AccountCurrency &&
                   OwnerId == account.OwnerId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(AccountId, AccountBalance, AccountCurrency, OwnerId);
        }
    }
}
