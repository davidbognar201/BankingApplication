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
    public class BankCard
    {
    

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardId { get; set; }
        public string Type { get; set; }
        public int CVCCode { get; set; }
        public string CardNumber { get; set; }
        public int AttachedAccountId { get; set; }
       // [NotMapped]
       // [JsonIgnore]
        //
        public virtual CurrentAccount AttachedAccount { get; set; }

        public BankCard(int cardId, string cardNumber, string type, int cvcCode, int attachedAccountId)
        {
            CardId = cardId;
            CardNumber = cardNumber;
            Type = type;
            CVCCode = cvcCode;
            AttachedAccountId = attachedAccountId;
        }
        public BankCard()
        {

        }

        public override string ToString()
        {
            return $"{CardId} -- {CardNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is BankCard card &&
                   CardId == card.CardId &&
                   Type == card.Type &&
                   CVCCode == card.CVCCode &&
                   CardNumber == card.CardNumber &&
                   AttachedAccountId == card.AttachedAccountId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CardId, Type, CVCCode, CardNumber, AttachedAccountId);
        }
    }
}
