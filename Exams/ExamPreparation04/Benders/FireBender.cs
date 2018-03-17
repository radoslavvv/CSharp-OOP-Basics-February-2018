using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FireBender : Bender
{
    public FireBender(string name, int power, decimal heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public decimal HeatAggression { get; set; }

    public override decimal GetTotalPower()
    {
        return this.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"###Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:0.00}";
    }
}

