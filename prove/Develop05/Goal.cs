public abstract class Goal
{
    string _goalName;
    string _description;
    int _pointValue;

    public Goal(string name, string description, int points)
    {
        _goalName = name;
        _description = description;
        _pointValue = points;
    }
    public int GetPointValue()
    {
        return _pointValue;
    }
    public abstract string FormatGoalToSave();
    public string GetGoalName()
    {
        return _goalName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public abstract int RecordGoal();
    public virtual void PrintGoal()
    {
        Console.WriteLine($"[ ] {_goalName} ({_description})");
    }
}