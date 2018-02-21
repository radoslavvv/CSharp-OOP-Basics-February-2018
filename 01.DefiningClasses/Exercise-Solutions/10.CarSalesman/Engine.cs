using System;

public class Engine
{
    private string model;
    private double power;
    private string displacement;
    private string efficiency;

    public Engine()
    {
        this.efficiency = "n/a";
        this.displacement = "n/a";
    }
    public Engine(string[] input):this()
    {
        this.model = input[0];
        this.power = double.Parse(input[1]);
        if (input.Length > 2)
        {
            for (int i = 2; i < input.Length; i++)
            {
                if (double.TryParse(input[i], out double result))
                {
                    this.Displacement = input[i];
                }
                else
                {
                    this.Efficiency = input[i];
                }
            }
        }
    }

    public override string ToString()
    {
        string result =
            $"  {this.Model}:\r\n" +
            $"    Power: {this.Power}\r\n" +
            $"    Displacement: {this.Displacement}\r\n" +
            $"    Efficiency: {this.Efficiency}";

        return result;
    }

    public string Model { get => model; set => model = value; }
    public double Power { get => power; set => power = value; }
    public string Displacement { get => displacement; set => displacement = value; }
    public string Efficiency { get => efficiency; set => efficiency = value; }
}
