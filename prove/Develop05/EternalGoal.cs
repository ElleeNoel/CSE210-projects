public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        
    }
    public override string FormatGoalToSave()
    {
        return $"EternalGoal;{GetGoalName()};{GetDescription()};{GetPointValue()}";
    }
    
    public override int RecordGoal()
    {
        return GetPointValue();
    }
}