using System;
using System.Collections.Generic;
using System.Linq;

public class CarSalesman
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        List<Engine> engines = new List<Engine>();

        int engineCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < engineCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Engine currentEngine = new Engine(parameters);

            engines.Add(currentEngine);
        }

        int carCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carCount; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string engineModel = parameters[1];

            Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
            Car currentCar = new Car(parameters, engine);

            cars.Add(currentCar);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}


