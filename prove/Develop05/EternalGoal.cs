public class EternalGoal : Goal
{
    //attributes


    //constructors
    public EternalGoal(string name, string description, int points) : base (name, description, points){}

    //behaviours
     public override int RecordEvent()
    {
        return GetPoints(); //always return poitns when recorded, an eternal goal can never be completed
    }
    public override bool IsComplete()
    {
        return false; //eternal goals can never be completed
    }
    public override string GetDisplayString()
    {   
        string name = GetName();
        string description = GetActivityDescription();

        return $"[ ] {name}, {description}"; //never gets checked off
    }
    public override string GetStringRepresentation() //for saving to file
    {   
        
        string name = GetName();
        string description = GetActivityDescription();
        int points = GetPoints();

        return $"Eternal#$%^*&{name}#$%^*&{description}#$%^*&{points}#$%^*&{false}"; //parse using the special characters to avoid comma issues
    }
    
}