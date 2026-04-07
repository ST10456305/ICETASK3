namespace CafeKiosk;

public class DrinkOrder
{
    public string CustomerName { get; set; } = string.Empty;
    public double BasePrice { get; set; }

    public virtual double CalculateTotal()
    {
        return BasePrice;
    }
}

public class PremiumDrink : DrinkOrder
{
    private string syrupFlavor = string.Empty;

    public string SyrupFlavor
    {
        get => syrupFlavor;
        set => syrupFlavor = value ?? string.Empty;
    }

    public override double CalculateTotal()
    {
        return BasePrice + 5.50;
    }
}
