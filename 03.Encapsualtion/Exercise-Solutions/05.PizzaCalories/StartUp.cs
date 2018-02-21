using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string[] firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);
            string[] secondLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);

            Dough dough = new Dough(secondLine[1], secondLine[2], double.Parse(secondLine[3]));
            Pizza pizza = new Pizza(firstLine[1], dough);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.None);

                Topping currentTopping = new Topping(data[1], double.Parse(data[2]));
                pizza.AddTopping(currentTopping);

                input = Console.ReadLine();
            }
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:0.00} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}

