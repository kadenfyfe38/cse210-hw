public abstract class Goal
{
    //attributes
    string _name;
    int _points;
    string _description;

    //Constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    //behaviours
    public string GetName()
    {
        return _name;
    }
    public int GetPoints()
    {
        return _points;
    }
    public string GetActivityDescription()
    {
        return _description;
    }
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDisplayString();
    public abstract string GetStringRepresentation();

}