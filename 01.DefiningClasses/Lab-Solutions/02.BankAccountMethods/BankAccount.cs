public class BankAccount
{
    private int id;
    private decimal balance;

    public int ID
    {
        get { return this.id = id; }
        set { this.id = value; }
    }
    public decimal Balance
    {
        get { return this.balance = balance; }
        set { this.balance = value; }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.ID}, balance {this.Balance}";
    }
}
