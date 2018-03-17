using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, long yearOfProduction, long horsePower, long acceleration, long suspension, long durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.HorsePower += this.HorsePower * 50 / 100;
        this.Suspension -= this.Suspension * 25 / 100;

        this.AddOns = new List<string>();
    }

    public List<string> AddOns { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());

        if (this.AddOns.Count == 0)
        {
            sb.Append("Add-ons: None");
        }
        else
        {
            sb.Append($"Add-ons: {string.Join(", ", this.AddOns)}");
        }

        return sb.ToString().Trim();
    }
}

