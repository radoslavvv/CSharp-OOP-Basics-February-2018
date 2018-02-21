using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        acc.Balance = 15;
        acc.ID = 1;

        Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
    }
}

