using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TimeLimitRace : Race
{
    public TimeLimitRace(long length, string route, long prizePool, long goldTime) : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public long GoldTime { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        Car participant = this.Participants.First().Value;

        long time = this.Length * ((participant.HorsePower / 100) * participant.Acceleration);

        string earnedTime = "";
        long wonPrize = 0;
        if (time <= this.GoldTime)
        {
            earnedTime = "Gold";
            wonPrize = this.PrizePool;
        }
        else if (time <= this.GoldTime + 15)
        {
            earnedTime = "Silver";
            wonPrize = (this.PrizePool * 50) / 100;
        }
        else if (time > this.GoldTime + 15)
        {
            earnedTime = "Bronze";
            wonPrize = (this.PrizePool * 30) / 100;
        }

        sb.AppendLine($"{participant.Brand} {participant.Model} - {time} s.");
        sb.AppendLine($"{earnedTime} Time, ${wonPrize}.");

        return sb.ToString();
    }
}

