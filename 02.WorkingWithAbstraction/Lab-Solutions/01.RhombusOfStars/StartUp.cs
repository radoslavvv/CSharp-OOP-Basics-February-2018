using System;
using System.Drawing;

public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        PrintRhombus(n);
    }

    private static void PrintRhombus(int n)
    {
        for (int row = 1; row < n; row++)
        {
            PrintRow(row, n);
        }
        for (int i = n; i >= 1; i--)
        {
            PrintRow(i, n);
        }
    }

    public static void PrintRow(int row, int n)
    {
        Console.Write($"{new string(' ', n - row)}");
        for (int j = 0; j < row; j++)
        {
            Console.Write($"* ");
        }
        Console.WriteLine($"{new string(' ', n - row)}");
    }
}

