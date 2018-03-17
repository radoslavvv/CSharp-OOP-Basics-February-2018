using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, long yearOfProduction, long horsePower, long acceleration, long suspension, long durability) : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public long Stars { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString();
    }
}

