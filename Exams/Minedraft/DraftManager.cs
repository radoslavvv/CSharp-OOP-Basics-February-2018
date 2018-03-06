using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private List<IHarvester> harvesters = new List<IHarvester>();
    private List<IProvider> providers = new List<IProvider>();

    private string mode = "Full";

    private double totalMinedOre = 0;
    private double totalEnergyStored = 0;

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            if (arguments.Count == 4)
            {
                double oreOutput = double.Parse(arguments[2]);
                double energyRequirement = double.Parse(arguments[3]);

                IHarvester harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                harvesters.Add(harvester);
            }
            else if (arguments.Count == 5)
            {
                double oreOutput = double.Parse(arguments[2]);
                double energyRequirement = double.Parse(arguments[3]);
                int sonicFactor = int.Parse(arguments[4]);

                IHarvester harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                harvesters.Add(harvester);
            }

            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            string type = arguments[0];
            string id = arguments[1];
            double energyOutput = double.Parse(arguments[2]);

            if (type == "Pressure")
            {
                IProvider provider = new PressureProvider(id, energyOutput);
                providers.Add(provider);
            }
            else if (type == "Solar")
            {
                IProvider provider = new SolarProvider(id, energyOutput);
                providers.Add(provider);
            }

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double generatedEnergy = providers.Sum(p => p.EnergyOutput);
        totalEnergyStored += generatedEnergy;

        double minedOres = 0;

        double neededEnergy;
        if (this.mode == "Half")
        {
            neededEnergy = harvesters.Sum(h => h.EnergyRequirement) * 0.6;
        }
        else if (this.mode == "Full")
        {
            neededEnergy = harvesters.Sum(h => h.EnergyRequirement);
        }
        else
        {
            return $"A day has passed.\r\n" +
                   $"Energy Provided: {generatedEnergy}\r\n" +
                   $"Plumbus Ore Mined: {minedOres}";
        }

        if (neededEnergy <= totalEnergyStored)
        {
            if (this.mode == "Full")
            {
                minedOres += harvesters.Sum(h => h.OreOutput);
                totalEnergyStored -= neededEnergy;
            }
            else
            {
                minedOres += harvesters.Sum(h => h.OreOutput * 0.5);
                totalEnergyStored -= neededEnergy * 0.6;
            }

            totalMinedOre += minedOres;
        }

        return $"A day has passed.\r\n" +
               $"Energy Provided: {generatedEnergy}\r\n" +
               $"Plumbus Ore Mined: {minedOres}";
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        IHarvester harvester = harvesters.FirstOrDefault(h => h.Id == id);
        IProvider provider = providers.FirstOrDefault(p => p.Id == id);

        if (harvester != null)
        {
            return $"{GetType().Name} Harvester - {harvester.Id}\r\n" +
                   $"Ore Output: {harvester.OreOutput}\r\n" +
                   $"Energy Requirement: {harvester.EnergyRequirement}";
        }
        else if (provider != null)
        {
            return $"{GetType().Name} Provider - {provider.Id}\r\n" +
                   $"Energy Output: {provider.EnergyOutput}";
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown\r\n" +
               $"Total Energy Stored: {totalEnergyStored}\r\n" +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}
