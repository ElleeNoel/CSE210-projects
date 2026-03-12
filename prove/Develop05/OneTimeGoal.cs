public class OneTimeGoal : Goal
{
    bool _completed;

    public OneTimeGoal(string name, string description, int points) : base(name, description, points)
    {
        _completed = false;
    }
    public OneTimeGoal(string name, string description, int points, string status) : base(name, description, points)
    {
        if (status == "true")
        {
            _completed = true;
        }
        else
        {
            _completed = false;
        }
    }
    public override string FormatGoalToSave()
    {
        // check example how it's formatted in save file
        return $"OneTimeGoal;{GetGoalName()};{GetDescription()};{GetPointValue()};{_completed}";
    }
    public override int RecordGoal()
    {
        _completed = true;
        return GetPointValue();
    }
    public override void PrintGoal()
    {
        if (_completed == true)
        {
            Console.WriteLine($"[X] {GetGoalName()} ({GetDescription()})");
        }
        else
        {
            base.PrintGoal();
        }
    }
 
}