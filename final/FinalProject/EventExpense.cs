public class EventExpense : BaseExpense
{
    private string _eventDate;

    public EventExpense(string name, double cost)
        : base(name, cost)
    {
        _eventDate = "No date";
    }

    public EventExpense(string name, double cost, string eventDate)
        : base(name, cost)
    {
        _eventDate = eventDate;
    }

    public override double CalculateCost()
    {
        return GetCost();
    }

    public override string GetDisplayText()
    {
        return $"{GetName()}: ${GetCost()} Event Date: {_eventDate}";
    }

    public string GetEventDate()
    {
        return _eventDate;
    }
}


