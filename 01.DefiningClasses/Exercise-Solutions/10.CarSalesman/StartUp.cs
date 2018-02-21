using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        int linesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < linesCount; i++)
        {
            string[] engine = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Engine currentEngine = new Engine(engine);

            engines.Add(currentEngine);
        }
        linesCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < linesCount; i++)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car currentCar = new Car(input, engines);
            cars.Add(currentCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

