using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    public Garage()
    {
        this.ParkedCars= new Dictionary<long, Car>();
    }

    public Dictionary<long, Car> ParkedCars { get; set; }

    public void ParkCar(int carId, Car car)
    {
        this.ParkedCars.Add(carId, car);
    }

    public void UnparkCar(int carId)
    {
        this.ParkedCars.Remove(carId);
    }
}

