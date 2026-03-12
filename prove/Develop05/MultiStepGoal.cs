public class MultiStepGoal : Goal
{
    int _completionBonus;
    int _timesToComplete;
    int _timesDone;
    bool _complete;
    public MultiStepGoal(string name, string description, int completePoints, int smallPoints, int timesToComplete) : base(name, description, smallPoints)
    {
        _complete = false;
        _timesToComplete = timesToComplete;
        _timesDone = 0;
        _completionBonus = completePoints;
    }
    public MultiStepGoal(string name, string description, int completePoints, int smallPoints, int timesToComplete, int timesCompleted) : base(name, description, smallPoints)
    {
        _timesToComplete = timesToComplete;
        _completionBonus = completePoints;
        _timesDone = timesCompleted;
        if (_timesDone < _timesToComplete)
        {
            _complete = false;
        }
        else
        {
            _complete = true;
        }
    }
    public override int RecordGoal()
    {
        if (_timesDone < _timesToComplete)
        {
            _timesDone +=1;
            return GetPointValue();
        }
        else
        {
            _complete = true;
            return GetPointValue() + _completionBonus;
        }
        
    }
    public override string FormatGoalToSave()
    {
        return $"MultiStepGoal;{GetGoalName()};{GetDescription()};{GetPointValue()};{_completionBonus};{_timesToComplete};{_timesDone}";
    }
    public override void PrintGoal()
    {
        if (_complete == true)
        {
            Console.WriteLine($"[X] {GetGoalName()} ({GetDescription()}) -- Currently completed: {_timesDone}/{_timesToComplete}");
        }
        else
        {
            Console.WriteLine($"[ ] {GetGoalName()} ({GetDescription()}) -- Currently completed: {_timesDone}/{_timesToComplete}");
        }
    }
}