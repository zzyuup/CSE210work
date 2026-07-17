public class OptionalPurchase : BaseExpense
{
    private string _priority;

    public OptionalPurchase(string name, double cost)
        : base(name, cost)
    {
        _priority = "Normal";
    }

    public OptionalPurchase(string name, double cost, string priority)
        : base(name, cost)
    {
        _priority = priority;
    }

    public override double CalculateCost()
    {
        return GetCost();
    }

    public override string GetDisplayText()
    {
        return $"{GetName()}: ${GetCost()} Priority: {_priority}";
    }

    public string GetPriority()
    {
        return _priority;
    }
}




