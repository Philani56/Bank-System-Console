using System;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the bank system to manage people and accounts
            BankSystem bankSystem = new BankSystem();

            // Keep showing the menu until the user decides to exit
            while (true)
            {
                Console.WriteLine("\n--- Bank System Menu ---");
                Console.WriteLine("1. Register Person");
                Console.WriteLine("2. Open Account");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Transfer Money");
                Console.WriteLine("6. Display Accounts");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option (1-7): ");
                string option = Console.ReadLine();

                // Handle user's choice using a switch statement
                switch (option)
                {
                    case "1":
                        RegisterPerson(bankSystem);
                        break;
                    case "2":
                        OpenAccount(bankSystem);
                        break;
                    case "3":
                        DepositMoney(bankSystem);
                        break;
                    case "4":
                        WithdrawMoney(bankSystem);
                        break;
                    case "5":
                        TransferMoney(bankSystem);
                        break;
                    case "6":
                        DisplayAccounts(bankSystem);
                        break;
                    case "7":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        // Method for registering a new person in the bank system
        private static void RegisterPerson(BankSystem bankSystem)
        {
            Console.Write("Enter person's name: ");
            string name = Console.ReadLine(); // Get name from user
            bankSystem.RegisterPerson(name);  // Register the person
        }

        // Method for opening an account for a registered person
        private static void OpenAccount(BankSystem bankSystem)
        {
            Console.Write("Enter person's name: ");
            string name = Console.ReadLine();
            Person person = bankSystem.GetPersonByName(name);

            if (person != null)
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Enter initial deposit: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
                {
                    person.OpenAccount(accountNumber, initialDeposit); // Open a new account
                }
                else
                {
                    Console.WriteLine("Invalid deposit amount.");
                }
            }
            else
            {
                Console.WriteLine($"Person '{name}' not found.");
            }
        }

        // Method for depositing money into a person's account
        private static void DepositMoney(BankSystem bankSystem)
        {
            Person person = GetPersonForTransaction(bankSystem);
            if (person != null)
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();
                BankAccount account = person.GetAccountByNumber(accountNumber);

                if (account != null)
                {
                    Console.Write("Enter deposit amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.Deposit(depositAmount); // Deposit the money
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount.");
                    }
                }
                else
                {
                    Console.WriteLine($"Account '{accountNumber}' not found.");
                }
            }
        }

        // Method for withdrawing money from a person's account
        private static void WithdrawMoney(BankSystem bankSystem)
        {
            Person person = GetPersonForTransaction(bankSystem);
            if (person != null)
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();
                BankAccount account = person.GetAccountByNumber(accountNumber);

                if (account != null)
                {
                    Console.Write("Enter withdrawal amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                    {
                        account.Withdraw(withdrawAmount); // Withdraw the money
                    }
                    else
                    {
                        Console.WriteLine("Invalid withdrawal amount.");
                    }
                }
                else
                {
                    Console.WriteLine($"Account '{accountNumber}' not found.");
                }
            }
        }

        // Method for transferring money between two accounts
        private static void TransferMoney(BankSystem bankSystem)
        {
            Person sender = GetPersonForTransaction(bankSystem);
            if (sender != null)
            {
                Console.Write("Enter sender's account number: ");
                string senderAccountNumber = Console.ReadLine();
                BankAccount senderAccount = sender.GetAccountByNumber(senderAccountNumber);

                if (senderAccount != null)
                {
                    Console.Write("Enter recipient's name: ");
                    string recipientName = Console.ReadLine();
                    Person recipient = bankSystem.GetPersonByName(recipientName);

                    if (recipient != null)
                    {
                        Console.Write("Enter recipient's account number: ");
                        string recipientAccountNumber = Console.ReadLine();
                        BankAccount recipientAccount = recipient.GetAccountByNumber(recipientAccountNumber);

                        if (recipientAccount != null)
                        {
                            Console.Write("Enter transfer amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                            {
                                senderAccount.Transfer(recipientAccount, transferAmount); // Transfer the money
                            }
                            else
                            {
                                Console.WriteLine("Invalid transfer amount.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Recipient's account '{recipientAccountNumber}' not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Recipient '{recipientName}' not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Sender's account '{senderAccountNumber}' not found.");
                }
            }
        }

        // Method to display all accounts for a specific person
        private static void DisplayAccounts(BankSystem bankSystem)
        {
            Person person = GetPersonForTransaction(bankSystem);
            if (person != null)
            {
                person.DisplayAccounts();
            }
        }

        // Helper method to get a person for transactions like deposit, withdraw, transfer, etc.
        private static Person GetPersonForTransaction(BankSystem bankSystem)
        {
            Console.Write("Enter person's name: ");
            string name = Console.ReadLine();
            Person person = bankSystem.GetPersonByName(name);

            if (person == null)
            {
                Console.WriteLine($"Person '{name}' not found.");
            }

            return person;
        }
    }
}

// References:

// 1. Microsoft Documentation: https://docs.microsoft.com/en-us/dotnet/csharp/
//    Used as a guide for understanding C# control structures and object-oriented programming concepts.

// 2. Stack Overflow: Assisted with examples for handling user input validation in console applications.

// 3. Pro C# 9 with .NET 5 by Andrew Troelsen: Reference for creating professional and scalable C# applications with proper class structures.
