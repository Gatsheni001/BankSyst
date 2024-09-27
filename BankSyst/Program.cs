using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSyst
{
    internal class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option: 1. Create Savings Account 2. Create Checking Account 3. Deposit 4. Withdraw 5. Apply Interest (Savings Account) 6. View Account Balance 7. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateSavingsAccount();
                        break;
                    case "2":
                        CreateCheckingAccount();
                        break;
                    case "3":
                        Deposit();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        ApplyInterest();
                        break;
                    case "6":
                        ViewAccountBalance();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateSavingsAccount()
        {
            Console.WriteLine("Enter account number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter initial balance:");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter interest rate (e.g., 0.05 for 5%):");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine());

            var savings = new SavingAccount(accountNumber, initialBalance, interestRate);
            accounts.Add(savings);

            Console.WriteLine("Savings account created.");
        }

        static void CreateCheckingAccount()
        {
            Console.WriteLine("Enter account number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter initial balance:");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

            var checking = new CheckingAccount(accountNumber, initialBalance);
            accounts.Add(checking);

            Console.WriteLine("Checking account created.");
        }

        static void Deposit()
        {
            Account account = FindAccount();
            if (account != null)
            {
                Console.WriteLine("Enter deposit amount:");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.Deposit(amount);
            }
        }

        static void Withdraw()
        {
            Account account = FindAccount();
            if (account != null)
            {
                Console.WriteLine("Enter withdrawal amount:");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.Withdraw(amount);
            }
        }

        static void ApplyInterest()
        {
            Account account = FindAccount();
            if (account is SavingAccount savingsAccount)
            {
                savingsAccount.ApplyInterest();
            }
            else
            {
                Console.WriteLine("Interest can only be applied to savings accounts.");
            }
        }

        static void ViewAccountBalance()
        {
            Account account = FindAccount();
            if (account != null)
            {
                Console.WriteLine($"Account balance: {account.Balance:C}");
            }
        }

        static Account FindAccount()
        {
            Console.WriteLine("Enter account number:");
            string accountNumber = Console.ReadLine();
            var account = accounts.Find(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
            }
            return account;
        }
    }
}
