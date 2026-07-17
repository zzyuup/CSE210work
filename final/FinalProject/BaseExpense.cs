public class BaseExpense
{
    private string _name;
    private double _cost;

    public BaseExpense(string name, double cost)
    {
        _name = name;
        _cost = cost;
    }

    public string GetName()
    {
        return _name;
    }

    public double GetCost()
    {
        return _cost;
    }

    public virtual double CalculateCost()
    {
        return _cost;
    }

    public virtual string GetDisplayText()
    {
        return $"{_name}: ${_cost}";
    }
}



