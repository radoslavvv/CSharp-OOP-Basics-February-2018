using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Race
{
    public Race(long length, string route, long prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, Car>();
    }

    public long Length { get; set; }

    public string Route { get; set; }

    public long PrizePool { get; set; }

    public Dictionary<int, Car> Participants { get; set; }

    public long GetMultiplier(long counter, string raceType)
    {
        long multiplier = 0;
        switch (counter)
        {
            case 1:
                multiplier = raceType == "Circuit" ? 40 : 50;
                break;
            case 2:
                multiplier = 30;
                break;
            case 3:
                multiplier = 20;
                break;
            case 4:
                multiplier = 10;
                break;
        }

        return multiplier;
    }
}

