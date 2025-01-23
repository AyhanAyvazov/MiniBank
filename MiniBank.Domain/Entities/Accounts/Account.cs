using MiniBank.Domain.Entities.Currencies;
using MiniBank.Domain.Entities.Customers; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace MiniBank.Domain.Entities.Accounts
{
    public class Account : EntityBase
    {
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public int AccountTypeId { get; set; }
        [ForeignKey("AccountTypeId")]
        public AccountType? AccountType { get; set; }
        public int AccountCurrencyId { get; set; }
        [ForeignKey("AccountCurrencyId")]
        public Currency? AccountCurrency { get; set; }
        public int AccountNumber { get; set; }
        public bool IsLocked { get; set; }

    }
}
