﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CasualRace : Race
{
    public CasualRace(long length, string route, long prizePool)
        : base(length, route, prizePool)
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        long counter = 1;
        foreach (var car in this.Participants.OrderByDescending(p => p.Value.GetOP()).Take(3))
        {
            long multiplier = GetMultiplier(counter, "Casual");

            sb.AppendLine($"{counter}. {car.Value.Brand} {car.Value.Model} {car.Value.GetOP()}PP - ${(this.PrizePool * multiplier) / 100}");

            counter++;
        }

        return sb.ToString();
    }
}

