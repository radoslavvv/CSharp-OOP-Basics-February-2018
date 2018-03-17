using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, decimal waterClarity)
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public decimal WaterClarity { get; set; }

    public override decimal GetTotalPower()
    {
        return this.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"###Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:0.00}";
    }
}

