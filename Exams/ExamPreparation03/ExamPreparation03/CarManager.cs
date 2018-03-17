using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Garage garage;
    private Dictionary<int, Race> openRaces;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.garage = new Garage();
        this.openRaces = new Dictionary<int, Race>();
    }

    public void Register(int id, string type, string brand, string model, long yearOfProduction, long horsepower,
        long acceleration, long suspension, long durability)
    {
        Car car = CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

        cars.Add(id, car);
    }

    private static Car CreateCar(string type, string brand, string model, long yearOfProduction, long horsepower, long acceleration, long suspension, long durability)
    {
        Car car = null;
        if (type == "Show")
        {
            car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }
        else if (type == "Performance")
        {
            car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        }

        return car;
    }

    public string Check(int id)
    {
        return cars[id].ToString().Trim();
    }

    public void Open(int id, string type, long length, string route, long prizePool)
    {
        Race race = null;
        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool);
                break;
            case "Drag":
                race = new DragRace(length, route, prizePool);
                break;
            case "Drift":
                race = new DriftRace(length, route, prizePool);
                break;
        }

        openRaces.Add(id, race);
    }

    public void Open(int id, string type, long length, string route, long prizePool, string bonus)
    {
        Race race = null;
        switch (type)
        {
            case "Circuit":
                long laps = long.Parse(bonus);
                race = new CircuitRace(length, route, prizePool, laps);
                break;
            case "TimeLimit":
                long goldTime = long.Parse(bonus);
                race = new TimeLimitRace(length, route, prizePool, goldTime);
                break;
        }

        openRaces.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.ContainsKey(carId))
        {
            string raceType = openRaces[raceId].GetType().Name;

            if ((raceType == "TimeLimitRace" && openRaces[raceId].Participants.Count == 0) || raceType != "TimeLimitRace")
            {
                openRaces[raceId].Participants.Add(carId, cars[carId]);
            }
        }
    }

    public string Start(int id)
    {
        Race race = openRaces[id];
        if (race.Participants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        openRaces.Remove(id);

        string raceType = race.GetType().Name;
        switch (raceType)
        {
            case "CasualRace":
                return ((CasualRace)race).ToString();
            case "DragRace":
                return ((DragRace)race).ToString();
            case "DriftRace":
                return ((DriftRace)race).ToString();
            case "TimeLimitRace":
                return ((TimeLimitRace)race).ToString();
            case "CircuitRace":
                return ((CircuitRace)race).ToString();
            default:
                return null;
        }
    }

    public void Park(int id)
    {
        foreach (var race in openRaces)
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return;
            }
        }
        garage.ParkedCars.Add(id, cars[id]);
    }

    public void Unpark(int id)
    {
        garage.ParkedCars.Remove(id);
    }

    public void Tune(long tuneIndex, string addOn)
    {
        if (garage.ParkedCars.Count != 0)
        {
            foreach (var car in garage.ParkedCars)
            {
                car.Value.HorsePower += tuneIndex;
                car.Value.Suspension += tuneIndex * 50 / 100;

                string carType = car.Value.GetType().Name;
                switch (carType)
                {
                    case "ShowCar":
                        ShowCar showCar = ((ShowCar)car.Value);
                        showCar.Stars += tuneIndex;
                        break;
                    case "PerformanceCar":
                        PerformanceCar performanceCar = ((PerformanceCar)car.Value);
                        performanceCar.AddOns.Add(addOn);
                        break;
                }
            }
        }
    }
}
