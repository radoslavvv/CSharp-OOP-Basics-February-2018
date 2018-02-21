using System;

public class Program
{
    public static void Main(string[] args)
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        try
        {
            Box currentBox = new Box(length, width, height);

            Console.WriteLine($"Surface Area - {currentBox.SurfaceArea:0.00}");
            Console.WriteLine($"Lateral Surface Area - {currentBox.LateralSurfaceArea:0.00}");
            Console.WriteLine($"Volume - {currentBox.Volume:0.00}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
