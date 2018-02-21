public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tire[] tires;

    public Car(string[] input)
    {
        this.model = input[0];
        this.engine = new Engine(double.Parse(input[1]), double.Parse(input[2]));
        this.cargo = new Cargo(double.Parse(input[3]), input[4]);

        this.tires = new Tire[]
        {
            new Tire(double.Parse(input[5])),
            new Tire(double.Parse(input[6])),
            new Tire(double.Parse(input[7])),
            new Tire(double.Parse(input[9]))
        };
    }

    public string Model
    {
        get => model;
        set => model = value;
    }

    public Engine Engine
    {
        get => engine;
        set => engine = value;
    }

    public Cargo Cargo
    {
        get => cargo;
        set => cargo = value;
    }

    public Tire[] Tires
    {
        get => tires;
        set => tires = value;
    }
}
