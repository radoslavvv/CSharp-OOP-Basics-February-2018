public class PriceCalculator
{
    private decimal pricePerDay;
    private int daysCount;
    private string season;
    private string discountType;
    private decimal result;

    public decimal PricePerDay { get => pricePerDay; set => pricePerDay = value; }
    public int DaysCount { get => daysCount; set => daysCount = value; }
    public string Season { get => season; set => season = value; }
    public string DiscountType { get => discountType; set => discountType = value; }
    public decimal Result { get => result; set => result = value; }
    
    public PriceCalculator(string[] input)
    {
        this.PricePerDay = decimal.Parse(input[0]);
        this.DaysCount = int.Parse(input[1]);
        this.Season = input[2];
        if (input.Length == 4)
        {
            this.DiscountType = input[3];
        }
        this.Result = 0;
    }

    public void CalculatePrice()
    {
        this.Result = (this.DaysCount * this.PricePerDay);

        MultiplyPriceBySeason();
        ApplyDiscount();
    }

    public void MultiplyPriceBySeason()
    {
        switch (this.Season)
        {
            case "Autumn":
                this.Result *= 1;
                break;
            case "Spring":
                this.Result *= 2;
                break;
            case "Winter":
                this.Result *= 3;
                break;
            case "Summer":
                this.Result *= 4;
                break;
        }
    }

    public void ApplyDiscount()
    {
        switch (this.DiscountType)
        {
            case "VIP":
                this.Result -= (this.Result * 0.20m);
                break;
            case "SecondVisit":
                this.Result -= (this.Result * 0.10m);
                break;
        }
    }

    public override string ToString()
    {
        return $"{this.Result:0.00}";
    }
}
