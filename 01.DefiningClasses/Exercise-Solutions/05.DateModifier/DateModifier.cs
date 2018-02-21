using System;
using System.Globalization;

public class DateModifier
{
    private double difference;

    public double Difference
    {
        get => this.difference;
        set => this.difference = value;
    }

    public double GetDifference(string dateOne, string dateTwo)
    {
        DateTime firstDate = DateTime.ParseExact(dateOne,"yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(dateTwo, "yyyy MM dd", CultureInfo.InvariantCulture);

        double difference = Math.Abs((secondDate - firstDate).TotalDays);
        this.difference = difference;

        return difference;
    }
}
