 using System.Text;

public class Engine
{

    private string model;
    private int power;
    private int displacement;
    private string efficiency;

    public Engine(string[] parameters)
    {
        this.model = parameters[0];
        this.power = int.Parse(parameters[1]);
        this.efficiency = "n/a";
        this.displacement = -1;

        if (parameters.Length >= 3)
        {
            if (int.TryParse(parameters[2], out int result))
            {
                this.displacement = result;
            }
            else
            {
                this.efficiency = parameters[2];
            }
            if (parameters.Length == 4)
            {
                this.efficiency = parameters[3];
            }
        }

    }

    public string Model { get => model; set => model = value; }
    public int Power { get => power; set => power = value; }
    public int Displacement { get => displacement; set => displacement = value; }
    public string Efficiency { get => efficiency; set => efficiency = value; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendFormat($"  {this.Model}:\n");
        sb.AppendFormat($"    Power: {this.Power}\n");

        if (this.Displacement == -1)
        {
            sb.AppendFormat($"    Displacement: n/a\n");
        }
        else
        {
            sb.AppendFormat($"    Displacement: {this.Displacement}\n");
        }
        sb.AppendFormat($"    Efficiency: {this.Efficiency}\n");

        return sb.ToString();
    }
}


