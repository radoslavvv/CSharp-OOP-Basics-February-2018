public class Cargo
{
    private double weight;
    private string type;

    public Cargo(double weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }

    public double Weight
    {
        get => weight;
        set => weight = value;
    }

    public string Type
    {
        get => type;
        set => type = value;
    }
}