using System;

public class Harvester : IHarvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get => id;
        protected set => id = value;
    }

    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement 
    {
        get => energyRequirement;
        protected set
        {
            if (value < 0 || value > 20_000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} Harvester - {this.Id}\r\n" +
               $"Ore Output: {this.OreOutput}\r\n" +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}
