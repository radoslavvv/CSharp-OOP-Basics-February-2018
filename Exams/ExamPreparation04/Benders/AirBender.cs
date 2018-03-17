using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirBender : Bender
{
    public AirBender(string name, int power, decimal aerialIntegrity)
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public decimal AerialIntegrity { get; set; }

    public override  decimal GetTotalPower()
    {
        return this.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return $"###Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:0.00}";
    }
}

