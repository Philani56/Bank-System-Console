using System;
using System.Collections.Generic;

namespace BankSystem
{
    // Represents a person who holds one or more bank accounts
    public class Person
    {
        // Auto-implemented properties for the person's name and list of bank accounts
        public string Name { get; private set; }
        public List<BankAccount> Accounts { get; private set; }

        // Constructor to initialize a person with a name and an empty list of accounts
        public Person(string name)
        {
            Name = name;
            Accounts = new List<BankAccount>();
        }

        // Method to create a new bank account for the person
        public void OpenAccount(string accountNumber, decimal initialDeposit)
        {
            BankAccount newAccount = new BankAccount(Name, accountNumber, initialDeposit);
            Accounts.Add(newAccount);
            Console.WriteLine($"Account successfully opened for {Name} with initial deposit of {initialDeposit:C}.");
        }

        // Method to get a bank account by its account number
        public BankAccount GetAccountByNumber(string accountNumber)
        {
            foreach (var account in Accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    return account;
                }
            }
            return null; // If account is not found
        }

        // Method to display all accounts for the person
        public void DisplayAccounts()
        {
            Console.WriteLine($"\n{Name}'s Bank Accounts:");
            foreach (var account in Accounts)
            {
                account.DisplayAccountInfo();
            }
        }
    }
}
