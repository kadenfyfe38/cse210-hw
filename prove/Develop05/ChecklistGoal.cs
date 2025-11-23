public class ChecklistGoal : Goal
{
    //attributes
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;
    //constructor
    public ChecklistGoal(string name, string description, int points, int targetCount):
    base(name, description, points)
    {
        _targetCount = targetCount;
    }
    //behaviours
    public int GetTargetCount()
    {
        return _targetCount;
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public void SetCurrentCount(int currentCount) //used for reading from file
    {
        _currentCount = currentCount;
    }
    public override int RecordEvent()
    {
        if (IsComplete()) //no points if you already completed it
        {
            return 0;
        }
        _currentCount+=1; //adds one to how many times youve done it

        int points = GetPoints();
        if (_currentCount == _targetCount)
        {
            int combinedPoints = points+_bonusPoints;
            return combinedPoints;
        }
        return points;
    }
    public override bool IsComplete()
    {
        return _currentCount>=_targetCount; //returns true if current count is equal to or bigger than target
    }
    public override string GetDisplayString() // for terminal user sees
    {
        string name = GetName();
        string description = GetActivityDescription();
        if (IsComplete())
        {
            return $"[X] {name} {description}";
        }
        else
        {
            return $"[ ] {name} {description} -- Completed {_currentCount}/{_targetCount}";
        }
    }
    public override string GetStringRepresentation() //for file
    {
        string name = GetName();
        string description = GetActivityDescription();
        int points = GetPoints();

        return $"Checklist#$%^*&{name}#$%^*&{description}#$%^*&{points}#$%^*&{IsComplete()}#$%^*&{_currentCount}#$%^*&{_targetCount}";
    }
}