public class Rectangle
{
    private string id;

    public string Id
    {
        get => id;
        set => id = value;
    }
    private double width;

    public double Width
    {
        get => width;
        set => width = value;
    }
    private double height;

    public double Height
    {
        get => height;
        set => height = value;
    }
    private double top;

    public double Top
    {
        get => top;
        set => top = value;
    }
    private double bot;

    public double Bot
    {
        get => bot;
        set => bot = value;
    }
    private double left;

    public double Left
    {
        get => left;
        set => left = value;
    }
    private double right;

    public double Right
    {
        get => right;
        set => right = value;
    }

    public Rectangle(string[] parameters)
    {
        this.Id = parameters[0];
        this.Width = double.Parse(parameters[1]);
        this.Height = double.Parse(parameters[2]);
        this.Left = double.Parse(parameters[3]);
        this.Top = double.Parse(parameters[4]);
        this.Bot = this.Top + this.Height;
        this.Right = this.Left + this.Width;
    }

    public bool Intersects(Rectangle otherRectangle)
    {
        return this.Left <= otherRectangle.Right && this.Right >= otherRectangle.Left &&
               this.Top <= otherRectangle.Bot && this.Bot >= otherRectangle.Top;
    }
}

