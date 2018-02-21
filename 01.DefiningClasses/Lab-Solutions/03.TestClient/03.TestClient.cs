using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = inputParams[0];
            int accountId = int.Parse(inputParams[1]);

            switch (command)
            {
                case "Create":
                    Create(accountId, accounts);
                    break;
                case "Deposit":
                    Deposit(accountId, decimal.Parse(inputParams[2]), accounts);
                    break;
                case "Withdraw":
                    Withdraw(accountId, decimal.Parse(inputParams[2]), accounts);
                    break;
                case "Print":
                    Print(accountId, accounts);
                    break;
            }
            input = Console.ReadLine();
        }
    }

    private static void Deposit(int accountId, decimal amount, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(accountId))
        {
            Console.WriteLine($"Account does not exist");
        }
        else
        {
            accounts[accountId].Deposit(amount);
        }
    }

    private static void Withdraw(int accountId, decimal amount, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(accountId))
        {
            Console.WriteLine($"Account does not exist");
        }
        else if (accounts[accountId].Balance - amount < 0)
        {
            Console.WriteLine($"Insufficient balance");
        }
        else
        {
            accounts[accountId].Withdraw(amount);
        }
    }

    public static void Create(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(accountId))
        {
            BankAccount newBankAccount = new BankAccount()
            {
                ID = accountId
            };
            
            accounts.Add(accountId, newBankAccount);
        }
        else
        {
            Console.WriteLine($"Account already exists");
        }
    }

    public static void Print(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (!accounts.ContainsKey(accountId))
        {
            Console.WriteLine($"Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[accountId].ToString());
        }

    }
}

