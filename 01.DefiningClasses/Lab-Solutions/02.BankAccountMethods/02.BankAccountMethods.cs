using System;

public class Program
{
    public static void Main()
    {
        BankAccount account = new BankAccount();
        account.Balance = 1337;
        account.ID = 15;

        Console.WriteLine(account);
    }
}

