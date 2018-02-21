using System.Collections.Generic;
using System.Linq;

public class Car
{
    private string model;
    private Engine engine;
    private string color;
    private string weight;

    public Car()
    {
        this.weight = "n/a";
        this.color = "n/a";
    }

    public Car(string[] parameters, List<Engine> engines):this()
    {
        this.model = parameters[0];
        this.engine = engines.First(e => e.Model == parameters[1]);

        if (parameters.Length > 2)
        {
            for (int i = 2; i < parameters.Length; i++)
            {
                if (double.TryParse(parameters[i], out double result))
                {
                    this.weight = parameters[i];
                }
                else
                {
                    this.color = parameters[i];
                }
            }
        }
    }

    public override string ToString()
    {
        string result = $"{this.Model}:\r\n" +
                        $"{this.Engine}\r\n" +
                        $"  Weight: {this.Weight}\r\n" +
                        $"  Color: {this.Color}";

        return result;
    }

    public string Model { get => model; set => model = value; }
    public Engine Engine { get => engine; set => engine = value; }
    public string Color { get => color; set => color = value; }
    public string Weight { get => weight; set => weight = value; }
}

