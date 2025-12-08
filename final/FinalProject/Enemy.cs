using System.Numerics;

public class Enemy : Actor
{
    //attributes

    //constructor
    public Enemy(string name, string type, Vector2 startPosition, int health) : base(name, "Enemy", startPosition, health)
    {}
    //behaviours
    public override void Move()
    {
        
        base.Move();
    }
}