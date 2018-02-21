using System;

public class StartUp
{
    public static void Main()
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();

        DateModifier dateModifier= new DateModifier();

        double difference = dateModifier.GetDifference(firstLine, secondLine);
        Console.WriteLine(difference);
    } 
}

