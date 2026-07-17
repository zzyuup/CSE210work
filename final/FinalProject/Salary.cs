public class Salary
{
    private double _amount;
    private string _timePeriod;

    public Salary(double amount, string timePeriod)
    {
        _amount = amount;
        _timePeriod = timePeriod;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public string GetTimePeriod()
    {
        return _timePeriod;
    }

    public void SetSalary(double amount)
    {
        _amount = amount;
    }

    public void SetTimePeriod(string timePeriod)
    {
        _timePeriod = timePeriod;
    }
}


