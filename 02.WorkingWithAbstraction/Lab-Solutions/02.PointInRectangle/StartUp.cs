using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Rectangle rectangle = ReadRectangle();

        int pointsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < pointsCount; i++)
        {
            Point currentPoint = ReadPoint();

            Console.WriteLine(rectangle.ContainsPoint(currentPoint));
        }
    }

    private static Rectangle ReadRectangle()
    {
        int[] inputParams = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Rectangle rectangle = new Rectangle()
        {
            TopLeft = new Point() { X = inputParams[0], Y = inputParams[1] },
            BotRight = new Point() { X = inputParams[2], Y = inputParams[3] }
        };
        return rectangle;
    }

    private static Point ReadPoint()
    {
        int[] currentPointParams = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Point currentPoint = new Point()
        {
            X = currentPointParams[0],
            Y = currentPointParams[1]
        };
        return currentPoint;
    }
}