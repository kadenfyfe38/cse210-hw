public class SimpleGoal : Goal
{
    //attributes
    private bool _isComplete;

    //constructor
    public SimpleGoal(string name, string description, int points, bool isComplete) : base (name, description, points)
    {
        _isComplete = isComplete;
    }
    //behaviours
    public override int RecordEvent()
    {
        if (_isComplete == true) //if it's true, don't give points again
        {
            return 0;
        } 
        else 
        _isComplete = true; //set it to complete
        return GetPoints(); //give user points for doing it
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetDisplayString()
    {   
        string name = GetName();
        string description = GetActivityDescription();
    
        if (_isComplete == true)
        {
            
            return $"[X] {name}, {description}";
        }
        else
        {
            return $"[ ] {name}, {description}";
        }
    }
    public override string GetStringRepresentation()
    {
        string name = GetName();
        string description = GetActivityDescription();
        int points = GetPoints();
        return $"Simple#$%^*&{name}#$%^*&{description}#$%^*&{points}#$%^*&{_isComplete}";
    }

}