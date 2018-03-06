using System;

public class Provider : IProvider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get => id;
        protected set => id = value;
    }

    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            if (value > 10_000 || value < 0)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"{GetType().Name} Provider - {this.Id}\r\n" +
               $"Energy Output: {this.EnergyOutput}";
    }
}
