public abstract class BaseGoal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public BaseGoal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public abstract int RecordEvent();

    public virtual bool IsComplete()
    {
        return _isComplete;
    }

    public virtual string GetDetailsString()
    {
        string checkbox = " ";

        if (IsComplete())
        {
            checkbox = "X";
        }

        return $"[{checkbox}] {_name} ({_description})";
    }

    public abstract string GetStringRepresentation();

    protected string GetName()
    {
        return _name;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    protected void SetComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }
}




