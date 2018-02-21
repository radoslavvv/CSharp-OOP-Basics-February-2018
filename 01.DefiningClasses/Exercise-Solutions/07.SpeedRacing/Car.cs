public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private decimal distanceTraveled;

    public string Model
    {
        get => this.model;
        set => this.model = value;
    }

    public decimal FuelAmount
    {
        get => this.fuelAmount;
        set => this.fuelAmount = value;
    }

    public decimal FuelConsumption
    {
        get => this.fuelConsumption;
        set => this.fuelConsumption = value;
    }

    public decimal DistanceTraveled
    {
        get => this.distanceTraveled;
        set => this.distanceTraveled = value;
    }

    public bool CarHasEnoughFuel(decimal distance)
    {
        return (this.FuelAmount - (distance * this.FuelConsumption)) >= 0;
    }

    public void CarTravelsDistance(decimal distance)
    {
        this.FuelAmount -= (distance * this.FuelConsumption);
        this.DistanceTraveled += distance;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:f2} {this.DistanceTraveled}";
    }
}
