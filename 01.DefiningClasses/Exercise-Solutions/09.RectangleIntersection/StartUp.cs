using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        double[] input = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        double rectanglesCount = input[0];
        double intersectionChecks = input[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < rectanglesCount; i++)
        {
            string[] inputParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Rectangle currentRectangle = new Rectangle(inputParams);
            rectangles.Add(currentRectangle);
        }
        for (int i = 0; i < intersectionChecks; i++)
        {
            string[] rectanglesToCheck = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Rectangle firstRectangle = rectangles.First(r => r.Id == rectanglesToCheck[0]);
            Rectangle secondRectangle = rectangles.First(r => r.Id == rectanglesToCheck[1]);

            if (firstRectangle.Intersects(secondRectangle))
            {
                Console.WriteLine($"true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}

