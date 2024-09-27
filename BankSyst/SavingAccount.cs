using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSyst
{
    internal class SavingAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(string accountNumber, decimal initialBalance, decimal interestRate)
            : base(accountNumber, initialBalance)
        {
            InterestRate = interestRate;
        }

        public void ApplyInterest()
        {
            var interest = Balance * InterestRate;
            Deposit(interest);
        }
    }
}
