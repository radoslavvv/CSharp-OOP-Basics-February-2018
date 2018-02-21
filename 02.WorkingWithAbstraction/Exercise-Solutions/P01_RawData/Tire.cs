public class Tire
{
    private double pressure;
    private double age;

    public Tire(double pressure, double age)
    {
        this.pressure = pressure;
        this.age = age;
    }

    public double Pressure { get => pressure; set => pressure = value; }
    public double Age { get => age; set => age = value; }
}
