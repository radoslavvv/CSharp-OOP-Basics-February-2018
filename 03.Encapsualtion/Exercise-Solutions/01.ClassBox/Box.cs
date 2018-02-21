public class Box
{
    private double length;
    private double width;
    private double height;
    private double surfaceArea;
    private double lateralSurfaceArea;
    private double volume;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double Length { get => length; set => length = value; }
    public double Width { get => width; set => width = value; }
    public double Height { get => height; set => height = value; }


    public double LateralSurfaceArea
    {
        get { return (2 * this.Length * this.Height) + (2 * this.Width * this.Height); }
    }
    public double Volume
    {
        get { return this.Length * this.Width * this.Height; }
    }

    public double SurfaceArea
    {
        get
        {
            return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
        }
    }
}