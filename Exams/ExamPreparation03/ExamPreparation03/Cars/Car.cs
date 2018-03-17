using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    protected Car(string brand, string model, long yearOfProduction, long horsePower, long acceleration, long suspension, long durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; set; }

    public string Model { get; set; }

    public long YearOfProduction { get; set; }

    public long HorsePower { get; set; }

    public long Acceleration { get; set; }

    public long Suspension { get; set; }

    public long Durability { get; set; }

    public long GetOP()
    {
        return (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public long GetEP()
    {
        return this.HorsePower / this.Acceleration;
    }

    public long GetSP()
    {
        return this.Suspension + this.Durability;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString().Trim();
    }
}

