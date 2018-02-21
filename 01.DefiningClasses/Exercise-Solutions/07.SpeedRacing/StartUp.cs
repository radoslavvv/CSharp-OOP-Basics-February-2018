using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        int carsCount = int.Parse(Console.ReadLine());
        Dictionary<string, Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < carsCount; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = input[0];
            decimal fuelAmount = decimal.Parse(input[1]);
            decimal fuelConsumption = decimal.Parse(input[2]);

            Car currentCar = new Car()
            {
                Model = model,
                FuelAmount = fuelAmount,
                FuelConsumption = fuelConsumption
            };

            cars.Add(model, currentCar);
        }

        string command = Console.ReadLine();
        while (command != "End")
        {
            string[] commandParams = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string model = commandParams[1];
            decimal distance = decimal.Parse(commandParams[2]);

            if (cars.ContainsKey(model))
            {
                if (cars[model].CarHasEnoughFuel(distance))
                {
                    cars[model].CarTravelsDistance(distance);
                }
                else
                {
                    Console.WriteLine($"Insufficient fuel for the drive");
                }
            }
            command = Console.ReadLine();
        }
        foreach (var car in cars.Values)
        {
            Console.WriteLine(car);
        }
    }
}

