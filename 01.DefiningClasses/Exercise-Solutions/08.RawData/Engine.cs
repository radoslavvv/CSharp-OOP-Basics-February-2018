public class Engine
{
    private double speed;
    private double power;

    public Engine(double speed, double power)
    {
        this.speed = speed;
        this.power = power;
    }

    public double Speed
    {
        get => speed;
        set => speed = value;
    }
    public double Power
    {
        get => power;
        set => power = value;
    }
}