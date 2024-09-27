using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSyst
{
    internal class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber, decimal intialBalance) : base(accountNumber, intialBalance)
        {

        }
        
            public override void Withdraw(decimal amount)
        {
           if ( Balance <= amount + 100 ) // OVERDRAFT LIMIT{
            {
                Balance -= amount;
                Console.WriteLine($"{amount:C} Withdrawn. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient Funds and overdraft limit reach.");
            }
        }
    }
    
}
