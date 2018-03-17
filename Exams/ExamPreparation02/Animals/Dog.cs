using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dog : Animal
{
    public Dog(string name, int age, int amountOfCommands, string adoptionCenterName)
        : base(name, age, adoptionCenterName)
    {
        this.AmountOfCommands = amountOfCommands;
    }

    public int AmountOfCommands { get; private set; }

}

