using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string currentMode = "Full";

    Dictionary<string, Harvester> harvesters = new Dictionary<string, Harvester>();
    Dictionary<string, Provider> providers = new Dictionary<string, Provider>();

    private double totalStoredEnergy = 0;
    private double totalMinedOre = 0;

    public string RegisterHarvester(List<string> args)
    {
        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(args);
            harvesters.Add(harvester.Id, harvester);

            return $"Successfully registered {args[0]} Harvester - {harvester.Id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public string RegisterProvider(List<string> args)
    {
        try
        {
            Provider provider = ProvidersFactory.CreateProvider(args);
            providers.Add(provider.Id, provider);

            return $"Successfully registered {args[0]} Provider - {provider.Id}";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double providedEnergy = providers.Sum(p => p.Value.EnergyOutput);
        totalStoredEnergy += providedEnergy;

        double neededEnergy = harvesters.Sum(h => h.Value.EnergyRequirement);

        double minedOre = 0;
        switch (currentMode)
        {
            case "Full":
                if (totalStoredEnergy >= neededEnergy)
                {
                    minedOre += harvesters.Sum(h => h.Value.OreOutput);
                    totalMinedOre += minedOre;
                    totalStoredEnergy -= neededEnergy;
                }
                break;
            case "Half":
                neededEnergy *= 0.6;
                if (totalStoredEnergy >= neededEnergy)
                {
                    minedOre += harvesters.Sum(h => h.Value.OreOutput * 0.5);
                    totalMinedOre += minedOre;
                    totalStoredEnergy -= neededEnergy;
                }
                break;
            case "Energy":
                break;
        }

        return $"A day has passed.\r\n" +
               $"Energy Provided: {providedEnergy}\r\n" +
               $"Plumbus Ore Mined: {minedOre}";
    }

    public string Mode(List<string> args)
    {
        string mode = args[0];
        currentMode = mode;

        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (providers.ContainsKey(id))
        {
            IProvider provider = providers[id];
            string type = provider.GetType().Name.Replace("Provider", "");

            return $"{type} Provider - {id}\r\n" +
                   $"Energy Output: {provider.EnergyOutput}";
        }
        else if (harvesters.ContainsKey(id))
        {
            IHarvester harvester = harvesters[id];
            string type = harvester.GetType().Name.Replace("Harvester", "");

            return $"{type} Harvester - {id}\r\n" +
                   $"Ore Output: {harvester.OreOutput}\r\n" +
                   $"Energy Requirement: {harvester.EnergyRequirement}";
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }

    public string ShutDown()
    {
        return $"System Shutdown\r\n" +
               $"Total Energy Stored: {totalStoredEnergy}\r\n" +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}