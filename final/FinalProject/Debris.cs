using System.Numerics;

public class Debris : Actor
{
    //attributes

    //constructor
    public Debris(string name, string type, Vector2 startPosition, int health) : base(name, "Debris", startPosition, 50)
    {}
    //behaviours
    public override void Move()
    {
        
        base.Move();
    }
}