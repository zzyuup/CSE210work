public class SimpleGoal : BaseGoal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        SetComplete(isComplete);
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        SetComplete(true);
        return GetPoints();
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}";
    }
}



