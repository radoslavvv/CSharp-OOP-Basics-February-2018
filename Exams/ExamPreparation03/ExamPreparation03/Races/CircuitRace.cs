using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CircuitRace : Race
{
    public CircuitRace(long length, string route, long prizePool, long laps) : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public long Laps { get; set; }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine($"{this.Route} - {this.Length * this.Laps}");

        foreach (var racer in this.Participants.Values)
        {
            racer.Durability -= (this.Length * this.Length) * this.Laps;
        }

        long counter = 1;
        foreach (var car in this.Participants.OrderByDescending(p => p.Value.GetOP()).Take(4))
        {
            long multiplier = GetMultiplier(counter, "Circuit");

            result.AppendLine($"{counter}. {car.Value.Brand} {car.Value.Model} {car.Value.GetOP()}PP - ${(this.PrizePool * multiplier) / 100}");

            counter++;
        }

        return result.ToString();
    }
}

