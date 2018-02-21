public class Rectangle
{
    private Point topLeft;
    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }

    private Point botRight;
    public Point BotRight
    {
        get { return botRight; }
        set { botRight = value; }
    }

    public bool ContainsPoint(Point point)
    {
        return (point.X >= this.TopLeft.X && point.X <= this.BotRight.X)
               && (point.Y <= this.BotRight.Y && point.Y >= this.TopLeft.Y);
    }
}
