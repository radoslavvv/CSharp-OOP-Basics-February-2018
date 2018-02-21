public class Car
{
    private string model;
    private double speed;

    public Car(string model, double speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        if (this.Model != "")
        {
            return $"\r\n{this.Model} {this.Speed}";
        }
        else
        {
            return $"";
        }
    }

    public string Model { get => model; set => model = value; }
    public double Speed { get => speed; set => speed = value; }
}
