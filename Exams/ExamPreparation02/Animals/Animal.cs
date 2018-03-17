using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Animal
{
    protected Animal(string name, int age, string adoptionCenterName)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = "UNCLEANSED";
        this.AdoptionCenter = adoptionCenterName;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string CleansingStatus { get; set; }

    public string AdoptionCenter { get; set; }
}

