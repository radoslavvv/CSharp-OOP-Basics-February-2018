using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Bender : Fighter
{
    public Bender(string name, int power)
    {
        this. Name = name;
        this. Power = power;
    }

    public string Name { get; set; }

    public virtual decimal GetTotalPower()
    {
        return this.Power;
    }

    public int Power { get; set; }

}


