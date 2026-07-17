public class RequiredExpense : BaseExpense
{
    private string _category;

    public RequiredExpense(string name, double cost)
        : base(name, cost)
    {
        _category = "Required";
    }

    public RequiredExpense(string name, double cost, string category)
        : base(name, cost)
    {
        _category = category;
    }

    public override double CalculateCost()
    {
        return GetCost();
    }

    public override string GetDisplayText()
    {
        return $"{GetName()}: ${GetCost()}";
    }

    public string GetCategory()
    {
        return _category;
    }
}




