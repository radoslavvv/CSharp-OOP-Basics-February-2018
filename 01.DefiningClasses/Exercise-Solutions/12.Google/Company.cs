public class Company
{
    private string name;
    private string department;
    private decimal salary;

    public Company(string name, string department, decimal salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        if (this.Name != "")
        {
            return $"\r\n{this.Name} {this.Department} {this.Salary:0.00}";
        }
        else
        {
            return $"";
        }
    }

    public string Name { get => name; set => name = value; }
    public string Department { get => department; set => department = value; }
    public decimal Salary { get => salary; set => salary = value; }
}