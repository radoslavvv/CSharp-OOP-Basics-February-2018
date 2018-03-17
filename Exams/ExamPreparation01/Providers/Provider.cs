using System;

public abstract class Provider : WorkingUnit, IProvider
{
    private double energyOutput;

    public Provider(string id, double energyOutput) : base(id)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }
    
    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            if (value < 0 || value > 10_000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's EnergyOutput");
            }

            this.energyOutput = value;
        }
    }
}

