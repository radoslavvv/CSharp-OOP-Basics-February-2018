public class Tire
{
    private double pressure;

    public Tire(double pressure)
    {
        this.pressure = pressure;
    }
    public double Pressure
    {
        get => this.pressure;
        set => this.pressure = value;
    }
}