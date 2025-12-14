using System.Numerics;

public class Enemy : Actor
{
    //attributes
    private int _size = 25;

    //constructor
    public Enemy(string name, string type, Vector2 startPosition, int health) : base(name, "Enemy", startPosition, 10)
    {
        SetVelocity(new Vector2(1,0));
    }
    //behaviours
    public override void Move()
    {
        base.Move();
    }

    public int GetSize()
    {
        return _size;
    }
    
}