using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cat : Animal
{
    public Cat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
        : base(name, age, adoptionCenterName)
    {
        this.IntelligenceCoefficient = intelligenceCoefficient;
    }

    public int IntelligenceCoefficient { get; private set; }
}

