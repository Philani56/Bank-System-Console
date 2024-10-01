using System;

namespace BankSystem
{
    // Represents a bank account with functionality to deposit, withdraw, and transfer funds
    public class BankAccount
    {
        // Auto-implemented properties for account holder name and balance
        public string AccountHolder { get; private set; }
        public decimal Balance { get; private set; }
        public string AccountNumber { get; private set; }

        // Constructor to initialize a new bank account with an account holder and initial balance
        public BankAccount(string accountHolder, string accountNumber, decimal initialDeposit)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = initialDeposit;
        }

        // Method to deposit money into the account
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
            else
            {
                Balance += amount;
                Console.WriteLine($"Successfully deposited {amount:C}. New Balance: {Balance:C}");
            }
        }

        // Method to withdraw money from the account
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Successfully withdrew {amount:C}. New Balance: {Balance:C}");
            }
        }

        // Method to transfer money between two accounts
        public void Transfer(BankAccount destinationAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Transfer amount must be positive.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for this transfer.");
            }
            else
            {
                this.Withdraw(amount);
                destinationAccount.Deposit(amount);
                Console.WriteLine($"Successfully transferred {amount:C} to {destinationAccount.AccountHolder}.");
            }
        }

        // Method to display account details
        public void DisplayAccountInfo()
        {
            Console.WriteLine($"\nAccount Holder: {AccountHolder}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Current Balance: {Balance:C}");
        }
    }
}
