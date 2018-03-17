using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, decimal groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public decimal GroundSaturation { get; set; }

    public override decimal GetTotalPower()
    {
        return this.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return $"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:0.00}";
    }
}

