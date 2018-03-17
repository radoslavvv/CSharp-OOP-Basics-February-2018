using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Center
{
    protected Center(string name)
    {
        this.Name = name;
        this.Animals = new List<Animal>();
    }

    public string Name { get; private set; }

    public List<Animal> Animals { get; private set; }
}

