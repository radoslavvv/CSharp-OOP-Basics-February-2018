using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NationsBuilder
{
    private List<KeyValuePair<string, Bender>> benders = new List<KeyValuePair<string, Bender>>();
    private List<KeyValuePair<string, Monument>> monuments = new List<KeyValuePair<string, Monument>>();

    private List<string> issuedWars = new List<string>();

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        decimal secondParameter = decimal.Parse(benderArgs[3]);

        Bender bender = null;
        switch (type)
        {
            case "Air":
                bender = new AirBender(name, power, secondParameter);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondParameter);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondParameter);
                break;
            case "Earth":
                bender = new EarthBender(name, power, secondParameter);
                break;
        }

        benders.Add(new KeyValuePair<string, Bender>(type, bender));
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        Monument monument = null;
        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                break;
        }

        monuments.Add(new KeyValuePair<string, Monument>(type, monument));
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");

        List<Bender> benders = this.benders.Where(b => b.Key == nationsType).Select(b => b.Value).ToList();

        if (benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine($"Benders:");
            sb.AppendLine($"{string.Join(Environment.NewLine, benders)}");
        }

        List<Monument> monuments = this.monuments.Where(m => m.Key == nationsType).Select(m => m.Value).ToList();
        if (monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine($"Monuments:");
            sb.AppendLine($"{string.Join(Environment.NewLine, monuments)}");
        }

        return sb.ToString();
    }

    public void IssueWar(string nationsType)
    {
        Dictionary<string, decimal> nations = new Dictionary<string, decimal>();

        decimal airPower = CalculatePower("Air");
        nations["Air"] = airPower;

        decimal earthPower = CalculatePower("Earth");
        nations["Earth"] = earthPower;

        decimal waterPower = CalculatePower("Water");
        nations["Water"] = waterPower;

        decimal firePower = CalculatePower("Fire");
        nations["Fire"] = firePower;

        string strongestNation = nations.OrderByDescending(n => n.Value).First().Key.Trim();

        benders.RemoveAll(b => b.Key != strongestNation);
        monuments.RemoveAll(m => m.Key != strongestNation);

        issuedWars.Add(nationsType);
    }

    private decimal CalculatePower(string nation)
    {
        decimal power = benders.Where(b => b.Key == nation).Sum(b => b.Value.GetTotalPower());

        decimal percentage = 0;
        switch (nation)
        {
            case "Air":
                percentage = monuments.Where(m => m.Key == "Air").Sum(m => ((AirMonument)m.Value).AirAffinity);
                break;
            case "Earth":
                percentage = monuments.Where(m => m.Key == "Earth").Sum(m => ((EarthMonument)m.Value).EarthAffinity);
                break;
            case "Water":
                percentage = monuments.Where(m => m.Key == "Water").Sum(m => ((WaterMonument)m.Value).WaterAffinity);
                break;
            case "Fire":
                percentage = monuments.Where(m => m.Key == "Fire").Sum(m => ((FireMonument)m.Value).FireAffinity);
                break;
        }

        power += (power / 100) * percentage;

        return power;
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();

        int warCount = 1;
        foreach (var nation in issuedWars)
        {
            sb.AppendLine($"War {warCount} issued by {nation}");
            warCount++;
        }

        return sb.ToString();
    }
}

