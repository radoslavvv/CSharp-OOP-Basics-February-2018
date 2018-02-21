using System;

public class Program
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        PriceCalculator calc = new PriceCalculator(input);

        calc.CalculatePrice();
        Console.WriteLine(calc);
    }
}

