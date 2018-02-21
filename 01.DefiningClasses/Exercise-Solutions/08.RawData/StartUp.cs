using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<Car> cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car currentCar = new Car(input);
            cars.Add(currentCar);
        }
        string lastLine = Console.ReadLine();
        if (lastLine == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (lastLine == "flamable")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

